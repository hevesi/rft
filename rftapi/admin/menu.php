<?php
    if(array_key_exists('uid', $_SESSION)):?>
    <table style="width:100%"> 
        <tr>
            <td style="width:10%"></td>
            <td style="text-align: center">
                <a href="<?=ADMIN_URL?>?A=myapikeys">My API Keys</a> |
                <?php if($_SESSION['rank'] == 1): ?>
                <a href="<?=ADMIN_URL?>?A=allapikeys">All API Keys</a> |
                <a href="<?=ADMIN_URL?>?A=userList">Admins list</a> | 
                <?php endif; ?>
                <a href="<?=ADMIN_URL?>?A=profil">Profil</a>
            </td>
            <td style="width:10%; text-align: center"><a href="<?=ADMIN_URL?>?A=logout">Log out!</a></td> 
        </tr>
    </table>
<table style="border: 1px; text-align: center">    
        
        
    <?php endif; ?>
