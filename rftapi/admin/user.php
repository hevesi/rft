<?php
if(array_key_exists('userEdit', $_POST))
{
    $data =[
        ':id' => $_GET['ID'],
        ':name' => $_POST['name'],
        ':email' => $_POST['email']
        ];
    
    if(!empty($_POST['pwd'])&& !empty($_POST['pwd_again']))
    {
        if($_POST['pwd'] === $_POST['pwd_again'])
        {
            $data[':password'] = hash('sha256', $_POST['pwd']);
        }
        else $_POST['error'] = 0;    
    }
    if(array_key_exists(':password', $data))
    {
        $q = "UPDATE rft_admin SET name = :name, email = :email, password = :password WHERE id = :id";
    }
    else 
    { 
        $q = "UPDATE rft_admin SET name = :name, email = :email WHERE id = :id";
    }    
    if(executeDML($q, $data))
    {
        $_POST['good'] = 0;
    }
    else 
    {
        $_POST['error'] = 0;
    }
    
}
if(array_key_exists('userAdd', $_POST)){  
    
    $data =[
        ':username' => $_POST['username'],
        ':name' => $_POST['name'],
        ':email' => $_POST['email']
        ];
    if(!is_null($_POST['pwd']) && !empty($_POST['pwd'])){
        if($_POST['pwd'] === $_POST['pwd_again']){
            $data[':password'] = hash('sha256', $_POST['pwd']);
        }else
            $_POST['error'] = 1;
    }
    
    if(array_key_exists(':password', $data)){
        $q = "INSERT INTO rft_admin (username,name, email, password) VALUES (:username, :name, :email, :password);";
    }
    if(executeDML($q, $data)){
        $_POST['good'] = 1;
    }
    else
        $_POST['error'] = 2;
}


if(array_key_exists('ID', $_GET))
{
 $query = "SELECT * FROM rft_admin WHERE id =:id";
 $user = QL_row($query, [':id' => $_GET['ID']]);
}

$errors = array("Error in modification!","The password and password are not the same again!","Error adding new user!");
$goods = array("Successful modification!","User successfully created!");
if(array_key_exists('error', $_POST)):?>
   <?=$errors[$_POST['error']]?>
<?php endif; ?>    
<?php if(array_key_exists('good', $_POST)):?>
    <?=$goods[$_POST['good']]?>
<?php endif;?>
<center>
<form action="" method="POST">
    <input type="text" placeholder="Username" name="username" value="<?=!empty($user)? $user['username'] : "" ?>" required /><br><br>
    <input type="text" placeholder="Name" name="name" value="<?=!empty($user)? $user['name'] : "" ?>" required /><br><br>
    <input type="text" placeholder="E-mail cím" name="email" value="<?=!empty($user)? $user['email'] : "" ?>" required /><br><br>
    <input type="password" placeholder="Password" name="pwd" <?php if('userAdd' == $_GET['A']) echo("required"); else echo(""); ?>/><br><br>
    <input type="password" placeholder="Password again" name="pwd_again"  <?php if('userAdd' == $_GET['A']) echo("required"); else echo(""); ?>/><br><br>
    <center><input type="submit" name="<?=$_GET['A']?>" value="Save"/></center>
</form>
</center>