<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <?php
        include_once 'core/database.php';
        function getFilms(){
            $query1 = QL_array('SELECT * FROM rft_filmek') ;
           // var_dump($query1);
            $a = "a";
            $asd = [
                'good'    => 'true',
                'array' => $query1
            ];
            return json_encode($asd);
        }
        function generateRandomString($length = 10) {
            $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
            $charactersLength = strlen($characters);
            $randomString = '';
            for ($i = 0; $i < $length; $i++) {
                $randomString .= $characters[rand(0, $charactersLength - 1)];
            }
            return $randomString;
        }
        echo generateRandomString(64);
        echo getFilms();
        $a = json_decode(getFilms(), true);
        var_dump($a);
        $ar = $a['array'];
        var_dump($ar);
        /*foreach ($a['array'] as $value) {
            echo $value[id];
        }*/
        
        ?>
    </body>
</html>
