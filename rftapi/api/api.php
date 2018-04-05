<?php
include_once '../core/database.php';

function Error($err  = '0x0'){
    $data = [
        'access'         => 'false',
        'successful'    => 'false',
        'errorcode' => $err
    ];
    return json_encode($data);
}

function HalfSuccess($error = []){
    $data = [
        'access'         => 'true',
        'successful'    => 'false'
    ];
    foreach ($error as $key => $value) {
        $data += [''.$key.'' => ''.$value.''];
    }
    return json_encode($data); 
}

function Success(){
    $data = [
        'access'         => 'true',
        'successful'    => 'true'
    ];
    return json_encode($data); 
}

function getValid($api = '',$security = ''){    
    $data =[
        ':apikey'        => $api        //$_GET['apikey'],
    ];
    //$exits = QL_row("SELECT * FROM rft_apikey WHERE apikey='k2huJIqBoyNbC4tt' AND securitykey='ic5bIpGxMHTfMvNwBOY6y5xcvi5wMUHifUXeeJZzznn0D';");
    $exits = QL_row("SELECT * FROM rft_apikey WHERE apikey=:apikey;", $data);
    if($exits['apikey'] == $api && $exits['securitykey'] == $security)
        return TRUE;
    elseif($exits['apikey'] == $api){
        echo Error('0x2');
        return FALSE;    
    }else
        return FALSE;
}

function getFilms(){
    $query = QL_array('SELECT * FROM rft_filmek') ;
    if($query != NULL){
        $qarray[] = null;
        $i = 0;
        foreach ($query as $value) {
            $tmp =[
                'id'        => $value['id'],
                'cim'       => $value['cim'],
                'mufaj'     => $value['mufaj'],
                'hossz'     => $value['hossz'],
                'rendezo'   => $value['rendezo'],
                'vetitike'  => $value['vetitike']
            ];
            $qarray[$i] = $tmp;
            $i++;
        }
        $data = [
            'access'         => 'true',
            'successful'    => 'true',
            'array' => $qarray
        ];
        return json_encode($data);    
    }else{
        $error = ['errorcode' => '0x6'];
        return HalfSuccess($error); 
    }
}

function getBuyers(){
    $query = QL_array('SELECT * FROM rft_vevok') ;
    if($query != NULL){
        $qarray[] = null;
        $i = 0;
        foreach ($query as $value) {
            $tmp =[
                'id'            => $value['id'],
                'nev'           => $value['nev'],
                'torzsvendeg'   => $value['torzsvendeg'],
                'latogatas'     => $value['latogatasSzama']
            ];
            $qarray[$i] = $tmp;
            $i++;
        }
        $data = [
            'access'         => 'true',
            'successful'    => 'true',
            'array' => $qarray
        ];
        return json_encode($data);
    }else{
        $error = ['errorcode' => '0x7'];
        return HalfSuccess($error);  
    }
}

function getBuying(){
    $query = QL_array('SELECT * FROM rft_vasarlasok');
    if($query != NULL){
        $qarray[] = null;
        $i = 0;
        foreach ($query as $value) {
            $tmp =[
                'vasarlasid'        => $value['vasarlasid'],
                'filmid'            => $value['filmid'],
                'vevoid'            => $value['vevoid'],
                'vasarlasideje'     => $value['vasarlasIdeje']
            ];
            $qarray[$i] = $tmp;
            $i++;
        }
        $data = [
            'access'         => 'true',
            'successful'    => 'true',
            'array' => $qarray
        ];
        return json_encode($data);
    }else{
        $error = ['errorcode' => '0x8'];
        return HalfSuccess($error);
    }
}

function getShow(){
    $query = QL_array('SELECT * FROM rft_eloadasok');
    if($query  != NULL){
        $qarray[] = null;
        $i = 0;
        foreach ($query as $value) {
            $tmp =[
                'id'        => $value['id'],
                'filmid'    => $value['filmid'],
                'idopont'   => $value['idopont']
            ];
            $qarray[$i] = $tmp;
            $i++;
        }
        $data = [
            'access'         => 'true',
            'successful'    => 'true',
            'array' => $qarray
        ];
        return json_encode($data);
    }else{
        $error = ['errorcode' => '0x9'];
        return HalfSuccess($error); 
    }
}

function getQuery($data){
    switch ($data["want"]){
        case "filmek":{
            echo getFilms();
            return;
        }
        case "vevok":{
            echo getBuyers();
            return;
        }
        case "eloadasok":{
            echo getShow();
            return;
        }
        case "vasarlasok":{
            echo getBuying();
            return;
        }
        default :{
           $error = ['errorcode' => '0x5'];
           echo HalfSuccess($error);
           return;
        }
    }
}

function setBuyer($data){
    $error = ['errorcode' => '0xa'];
    if(array_key_exists("nev", $data) && array_key_exists("torzsvendeg", $data)){
        if(executeDML("INSERT INTO rft_vevok(nev,torzsvendeg) VALUES(:nev, :torzs)", [':nev' => $data['nev'], ':torzs' => $data['torzsvendeg']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }elseif (array_key_exists("nev", $data)) {
        if(executeDML("INSERT INTO rft_vevok(nev) VALUES(:nev)", [':nev' => $data['nev']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    } else {
        echo HalfSuccess($error);
    }
}

function setMovies($data){
    $error = ['errorcode' => '0xb'];
    if(array_key_exists("cim", $data) && array_key_exists("mufaj", $data) && array_key_exists("hossz", $data) && array_key_exists("rendezo", $data) && array_key_exists("vetitike", $data)){
        if(executeDML("INSERT INTO rft_filmek(cim,mufaj,hossz,rendezo,vetitike) VALUES(:com, :mufaj, :hossz, :rendezo, :vetitike)", 
                [':cim' => $data['cim'], ':mufaj' => $data['mufaj'], ':hossz' => $data['hossz'], ':vetitike' => $data['vetitike']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }elseif(array_key_exists("cim", $data) && array_key_exists("mufaj", $data) && array_key_exists("hossz", $data) && array_key_exists("rendezo", $data)){
        if(executeDML("INSERT INTO rft_filmek(cim,mufaj,hossz,rendezo,vetitike) VALUES(:com, :mufaj, :hossz, :rendezo)", 
                [':cim' => $data['cim'], ':mufaj' => $data['mufaj'], ':hossz' => $data['hossz']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }elseif (array_key_exists("nev", $data)) {
        if(executeDML("INSERT INTO rft_filmek(cim) VALUES(:cim)", [':cim' => $data['cim']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    } else {
        echo HalfSuccess($error);
    }
}

function setPresentations($data){
    $error = ['errorcode' => '0xc'];
    if(array_key_exists("filmid", $data) && array_key_exists("idopont", $data)){
        if(executeDML("INSERT INTO rft_eloadasok(filmid,idopont) VALUES(:fid, :idopont)", [':fid' => $data['filmid'], ':idopont' => $data['idopont']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }else {
        echo HalfSuccess($error);
    }
}

function setBuying($data){
    $error = ['errorcode' => '0xd'];
    if(array_key_exists("filmid", $data) && array_key_exists("vevoid", $data) && array_key_exists("ido", $data)){
        if(executeDML("INSERT INTO rft_vasarlasok(filmid,vevoid,vasarlasIdeje) VALUES(:fid, :vevoid, :ido)", [':fid' => $data['filmid'], ':vevoid' => $data['vevoid'],':ido' => $data['ido']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }elseif(array_key_exists("filmid", $data) && array_key_exists("vevoid", $data)){
        if(executeDML("INSERT INTO rft_vasarlasok(filmid,vevoid) VALUES(:fid, :vevoid)", [':fid' => $data['filmid'], ':vevoid' => $data['vevoid']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }else {
        echo HalfSuccess($error);
    }
}

function setInsert($data){
    switch ($data["want"]){
        case "buyer":{
            setBuyer($data);
            return;
        }break;
        case "movie":{
            setMovies($data);
            return;
        }break;
        case "pre":{
            setPresentations($data);
            return;
        }
        case "buying":{
            setBuying($data);
            return;
        }
        default :{
            $error = ['errorcode' => '0x5'];
            echo HalfSuccess($error); 
        }
    }
}

function updateBuyer($data){
    $error = ['errorcode' => '0xe'];
    if(array_key_exists("id", $data) && array_key_exists("nev", $data) && array_key_exists("torzsvendeg", $data) && array_key_exists("szam", $data)){
        if(executeDML("UPDATE rft_vevok SET nev=:nev, torzsvendeg=:torzsvendeg, latogatasSzama=:szam WHERE id=:id", 
                [':id' => $data['id'], ':nev' => $data['nev'],':torzsvendeg' => $data['torzsvendeg'],':szam' => $data['szam']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }else {
        echo HalfSuccess($error);
    }
}

function updateMovies($data){
    $error = ['errorcode' => '0xf'];
    if(array_key_exists("id", $data) && array_key_exists("cim", $data) && array_key_exists("hossz", $data) && array_key_exists("mufaj", $data) && array_key_exists("rendezo", $data)){
        if(executeDML("UPDATE rft_filmek SET cim=:cim, mufaj=:mufaj, hossz=:hossz, rendezo=:rendezo WHERE id=:id", 
                [':id' => $data['id'], ':cim' => $data['cim'],':mufaj' => $data['mufaj'],':hossz' => $data['hossz'],':rendezo' => $data['rendezo']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }elseif(array_key_exists("id", $data) && array_key_exists("cim", $data)){
        if(executeDML("UPDATE rft_filmek SET cim=:cim WHERE id=:id", [':id' => $data['id'], ':cim' => $data['cim']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }else {
        echo HalfSuccess($error);
    }
}

function updatePresentations($data){
    $error = ['errorcode' => '0x10'];
    if(array_key_exists("id", $data) && array_key_exists("idopont", $data) && array_key_exists("filmid", $data)){
        if(executeDML("UPDATE rft_eloadasok SET filmid=:filmid, idopont=:idopont WHERE id=:id", [':id' => $data['id'], ':filmid' => $data['filmid'],':idopont' => $data['idopont']]))
            echo Success();
        else 
            echo HalfSuccess($error);
    }else {
        echo HalfSuccess($error);
    }
}

function setUpdate($data){
    switch ($data["want"]){
        case "buyer":{
            updateBuyer($data);
            return;
        }break;
        case "movie":{
            updateMovies($data);
            return;
        }break;
        case "pre":{
            updatePresentations($data);
            return;
        }
        default :{
            $error = ['errorcode' => '0x5'];
            echo HalfSuccess($error); 
        }
    }
}

if(array_key_exists("data", $_POST)){    
    if($_POST['data'] != NULL && $_POST['data'] != ""){
        $data = json_decode((string)$_POST['data'], true);
        if(getValid($data['apikey'], $data['securitykey'])){
            switch ($data['request']){
                case "0":{ //query
                    getQuery($data);
                }break;
                case "1":{ //insert
                    setInsert($data);
                }break;
                case "2":{ //updaate
                    setUpdate($data);
                }break;
                case "3":{ //delete (in the near future)
                }break;
                default :{
                    $error = ['errorcode' => '0x4'];
                    echo HalfSuccess($error);
                }break;
            }
            return;
        }else{
            echo Error('0x1');
            return ;
        }
    }else{
        echo Error('0x3');
        return;
    }
}
echo Error();
?>
