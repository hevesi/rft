<?php
function generateRandomString($length) {
            $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
            $charactersLength = strlen($characters);
            $randomString = '';
            for ($i = 0; $i < $length; $i++) {
                $randomString .= $characters[rand(0, $charactersLength - 1)];
            }
            return $randomString;
}

if(array_key_exists('uid', $_SESSION)){
    $apiKey = generateRandomString(16);
    $securityKey = generateRandomString(45);
    $query = "INSERT INTO rft_apikey(apikey,securitykey,`owner`)
              VALUES(:apikey, :securitykey, :owner)";
    $params=[
        ':apikey'       => $apiKey,
        ':securitykey'  => $securityKey,
        ':owner'        => $_SESSION['uid']
    ];     
    if(executeDML($query, $params )){
        echo '<center><h1>New API access</h1>';
        echo '<b>API key:</b> '. $apiKey .'<br>';
        echo '<b>Security key:</b> '.$securityKey .'</center><br>';    
    } else {
        echo '<center><h1>ERROR</h1></center>';   
    }
}
?>

