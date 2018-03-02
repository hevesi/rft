<?php
if(array_key_exists('login', $_POST)){
    $query = "SELECT * 
              FROM rft_admin 
              WHERE username = :username AND password = :password";
    $params = [
        ':username'    =>  $_POST['username'],
        ':password' => hash('sha256', $_POST['password'])
    ];
    $row = QL_row($query, $params);
    if($row !== null && $row['id'] !== null){
        $_SESSION['uid'] = $row['id'];
       header('Location:'.ADMIN_URL);
    }else{
        $query1 = "SELECT * 
              FROM rft_admin 
              WHERE username = :username";
        $params1 = [
            ':username'    =>  $_POST['username']
        ];
        $row1 = QL_row($query1, $params1);
        if($row1 !== null && $row1['id'] !== null && $row1['password'] != hash('sha256', $_POST['password']))
            header('Location:'.ADMIN_URL.'?error=0');   
        else
            header('Location:'.ADMIN_URL.'?error=1');
    }
   
}

if(array_key_exists('uid', $_SESSION) && array_key_exists('A', $_GET) && $_GET['A'] === 'logout'){    
    session_destroy();
    header_remove();
    header('Location: '.ADMIN_URL);
}

if(!array_key_exists('uid', $_SESSION)){
    include_once ADMIN_ROOT.'login/form.php';
    return;
}
if(array_key_exists('uid', $_SESSION) && array_key_exists('A', $_GET) &&  $_GET['A'] === 'myapikeys'){
    include_once ADMIN_ROOT.'myapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION) && array_key_exists('A', $_GET) &&  $_GET['A'] === 'allapikeys'){
    include_once ADMIN_ROOT.'allapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION) && array_key_exists('A', $_GET) &&  $_GET['A'] === 'userList'){
    include_once ADMIN_ROOT.'userlist.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'userDelete'){
    include_once ADMIN_ROOT.'userlist.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'userInactive'){
    include_once ADMIN_ROOT.'userlist.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'userActive'){
    include_once ADMIN_ROOT.'userlist.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'apiDelete'){
    include_once ADMIN_ROOT.'myapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'apiInactive'){
    include_once ADMIN_ROOT.'myapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'apiActive'){
    include_once ADMIN_ROOT.'myapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'allapiDelete'){
    include_once ADMIN_ROOT.'allapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'allapiInactive'){
    include_once ADMIN_ROOT.'allapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'allapiActive'){
    include_once ADMIN_ROOT.'allapikeys.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'addNewAPI'){
    include_once ADMIN_ROOT.'addAPI.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'userEdit'){   
    include_once ADMIN_ROOT.'user.php';
    return;
}
if(array_key_exists('uid', $_SESSION)&& array_key_exists('A', $_GET) && $_GET['A'] === 'userAdd'){
    include_once ADMIN_ROOT.'user.php';
    return;
}

include_once ADMIN_ROOT.'wellcome.php';

?>
