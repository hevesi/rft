<?php
include_once '../core/database.php';

function Error(){
    $data = [
        'access'         => 'false',
        'successful'    => 'false'
    ];
    return json_encode($data);
}

function getValid($api = '',$security = ''){    
    $data =[
        'apikey'        => $_GET['apikey'],
        'securitykey'   => $_GET['securitykey']
    ];
    $g = "SELECT * FROM rft_apikey where apikey=:apikey AND securitykey=:securitykey;";
    $exits = QL_row("SELECT * FROM rft_apikey where apikey='k2huJIqBoyNbC4tt' AND securitykey='ic5bIpGxMHTfMvNwBOY6y5xcvi5wMUHifUXeeJZzznn0D';");
    if(!$exits)
        return FALSE;
    else
        return TRUE;     
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
        $data = [
            'access'         => 'true',
            'successful'    => 'false'
        ];
        return json_encode($data); 
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
        $data = [
            'access'         => 'true',
            'successful'    => 'false'
        ];
        return json_encode($data); 
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
                'vasarlasideje'     => $value['vasarlasideje']
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
        $data = [
            'access'         => 'true',
            'successful'    => 'false'
        ];
        return json_encode($data); 
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
        $data = [
            'access'         => 'true',
            'successful'    => 'false'
        ];
        return json_encode($data); 
    }
}

function getQuery($want){
    switch ($want){
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
    }
}

if(array_key_exists("apikey", $_GET) && array_key_exists("securitykey", $_GET)){
    if(getValid($_GET['apikey'], $_GET['securitykey'])){
        switch ($_GET['request']){
            case "query":{
                    getQuery($_GET['want']);
            }break;
            default :{
                $data = [
                    'access'         => 'true',
                    'successful'    => 'false'
                ];
                echo json_encode($data); 
            }break;
        }
        return;
    }else{
        echo Error();
        return;
    }  
}
echo Error();
?>
