<?php
    if(array_key_exists('A', $_GET)){
        if(array_key_exists('ID', $_GET) && $_GET['A'] === 'apiDelete'){  
            $q = "DELETE FROM rft_apikey where id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);  
            header("Refresh:0; url=index.php?A=myapikeys");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'apiInactive'){
            $q = "UPDATE rft_apikey SET active = 0 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=myapikeys");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'apiActive'){
            $q = "UPDATE rft_apikey SET active = 1 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=myapikeys");
        }
    }      
    if(array_key_exists('uid', $_SESSION)){
        $query  = "SELECT * 
                   FROM rft_apikey
                   WHERE `owner`=:id";
        $result = QL_array($query,[':id' => $_SESSION['uid']]);
    }
?>
<center>
    <br><a href="<?=ADMIN_URL?>?A=addNewAPI">Add new API Key</a><br><br>
</center>
    <table align="center" border="1">
        <thead style="text-align: center">
            <tr>
                <th>API Key</th>
                <th>Security Key</th>
                <th>Operations</th>
            </tr>           
        </thead>
        <tbody style="text-align: center">
            <?php foreach($result as $row):?>
            <tr>
                <td><?=$row['apikey'] ?></td>
                <td><?=$row['securitykey'] ?></td>
                <td>
                    <a href="<?=ADMIN_URL?>?A=apiDelete&ID=<?=$row['id']?>"><img src="../images/trash.png" height="20" width="20"></a>
                    <?php if((int)$row['active'] === 1): ?>
                        <a href="<?=ADMIN_URL?>?A=apiInactive&ID=<?=$row['id']?>"><img src="../images/open.png" height="20" width="20"></a>
                    <?php else : ?>
                        <a href="<?=ADMIN_URL?>?A=apiActive&ID=<?=$row['id']?>"><img src="../images/closed.png"  height="20" width="20"></a>
                    <?php endif; ?>
                </td>
            </tr>
            <?php endforeach;?>
        </tbody>
    </table>
