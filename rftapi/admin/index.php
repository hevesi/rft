<?php
    session_start();
    
    include_once '../core/database.php';
    
    define('ADMIN_ROOT', '../admin/');
    define('ADMIN_URL','http://localhost/rftapi/admin/index.php');
    $errors = array("The username password is incorrect!","Username not found!");
?>
<html>
    <head>
        <title>Admin interface</title>
    </head>
    <body>
        <div class ="body">
            <?php if($_SESSION != null) : ?>
                <div class="header">
                    <?php include_once ADMIN_ROOT.'header.php'; ?>
                </div>            
                <div class="menu">
                    <?php include_once ADMIN_ROOT.'menu.php'; ?>
                </div>
            
            <div class="content"> 
                <?php endif; ?>
                <?php include_once ADMIN_ROOT.'content.php'; ?>
            </div>
            <div class="footer">
                <?php include_once ADMIN_ROOT.'footer.php'; ?>
            </div>
        </div>
</html>