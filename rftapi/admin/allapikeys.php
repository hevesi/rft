<?php
    if(array_key_exists('A', $_GET)){
        if(array_key_exists('ID', $_GET) && $_GET['A'] === 'allapiDelete'){  
            $q = "DELETE FROM rft_apikey where id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);  
            header("Refresh:0; url=index.php?A=allapikeys");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'allapiInactive'){
            $q = "UPDATE rft_apikey SET active = 0 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=allapikeys");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'allapiActive'){
            $q = "UPDATE rft_apikey SET active = 1 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=allapikeys");
        }
    }      
    if(array_key_exists('uid', $_SESSION)){
        $query  = "SELECT rft_apikey.id, rft_apikey.apikey,rft_apikey.securitykey, rft_apikey.active, rft_admin.username
                   FROM rft_apikey 
                   LEFT JOIN rft_admin ON rft_apikey.`owner` = rft_admin.id;";
        $result = QL_array($query);
    }
?>
<br>
    <table align="center" border="1">
        <thead style="text-align: center">
            <tr>
                <th>API Key</th>
                <th>Security Key</th>
                <th>Owner</th>
                <th>Operations</th>
            </tr>           
        </thead>
        <tbody style="text-align: center">
            <?php foreach($result as $row):?>
            <tr>
                <td><?=$row['apikey'] ?></td>
                <td><?=$row['securitykey'] ?></td>
                <td><?=$row['username'] ?></td>
                <td>
                    <a href="<?=ADMIN_URL?>?A=allapiDelete&ID=<?=$row['id']?>"><img src="../images/trash.png" height="20" width="20"></a>
                    <?php if((int)$row['active'] === 1): ?>
                        <a href="<?=ADMIN_URL?>?A=allapiInactive&ID=<?=$row['id']?>"><img src="../images/open.png" height="20" width="20"></a>
                    <?php else : ?>
                        <a href="<?=ADMIN_URL?>?A=allapiActive&ID=<?=$row['id']?>"><img src="../images/closed.png"  height="20" width="20"></a>
                    <?php endif; ?>
                </td>
            </tr>
            <?php endforeach;?>
        </tbody>
    </table>
