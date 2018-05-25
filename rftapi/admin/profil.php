<?php
    if(array_key_exists('userEdit', $_POST))
    {
        $data =[
            ':id' => $_SESSION['uid'],
            ':name' => $_POST['name'],
            ':email' => $_POST['email']
            ];

        if(!empty($_POST['pwd'])&& !empty($_POST['pwd_again']))
        {
            $_POST['saadsdsad'] = 1;
            if($_POST['pwd'] === $_POST['pwd_again'])
            {
                $data[':password'] = hash('sha256', $_POST['pwd']);
            }
            else $_POST['error'] = 1;    
        }
        if(!empty($_POST['pwd']) || !empty($_POST['pwd_again'])){
            $_POST['error'] = 1;
        }
        elseif(array_key_exists(':password', $data))
        {
            $q = "UPDATE rft_admin SET name = :name, email = :email, password = :password WHERE id = :id";
        }
        else 
        { 
            $q = "UPDATE rft_admin SET name = :name, email = :email WHERE id = :id";
        }    
        if(!isset($_POST['error']) && executeDML($q, $data))
        {
            $_POST['good'] = 0;
        }
        elseif(!isset($_POST['error']))
        {
            $_POST['error'] = 0;
        }

    }
    $query  = "SELECT * FROM rft_admin WHERE id = :id;";
    $params = [
        ':id'   =>$_SESSION['uid']
    ];
    $user = QL_row($query, $params);
    $errors = array("Error in modification!","The password and password are not the same again!");
    $goods = array("Successful modification!");
if(array_key_exists('error', $_POST)):?>
   <?=$errors[$_POST['error']]?>
<?php endif; ?>    
<?php if(array_key_exists('good', $_POST)):?>
    <?=$goods[$_POST['good']]?>
<?php endif;?>
<center>
<form action="" method="POST">
    <input type="text" placeholder="Name" name="name" value="<?=!empty($user)? $user['name'] : "" ?>" required /><br><br>
    <input type="text" placeholder="E-mail cím" name="email" value="<?=!empty($user)? $user['email'] : "" ?>" required /><br><br>
    <input type="password" placeholder="Password" name="pwd" <?php if('userAdd' == $_GET['A']) echo("required"); else echo(""); ?>/><br><br>
    <input type="password" placeholder="Password again" name="pwd_again"  <?php if('userAdd' == $_GET['A']) echo("required"); else echo(""); ?>/><br><br>
    <center><input type="submit" name="userEdit" value="Save"/></center>
</form>
</center>
