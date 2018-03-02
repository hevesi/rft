<!DOCTYPE html>

        <?php
        include_once '../core/database.php';
        function getFilms(){
            $query1 = QL_array('SELECT * FROM rft_filmek') ;
           // var_dump($query1);
            $a = "a";
            $qarray[] = null;
            $i = 0;
            foreach ($query1 as $value) {
                $tmp =[
                    'id'        => $value['id'],
                    'cim'       => $value['cim'],
                    'mufaj'     => $value['mufaj'],
                    'hossz'     => $value['hossz'],
                    'rendezo'   =>$value['rendezo'],
                    'vetitike'  =>$value['vetitike']
                ];
                $qarray[$i] = $tmp;
                $i++;
            }
            $asd = [
                'good'    => 'true',
                'array' => $qarray
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
        //var_dump($a);
        $ar = $a['array'];
        //var_dump($ar);
        /*foreach ($a['array'] as $value) {
            echo $value[id];
        }*/
        echo '<br><br>api key: '. generateRandomString(16) .'<br>';
        echo 'security key: '. generateRandomString(45);
        ?>
