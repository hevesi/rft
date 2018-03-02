<?php 
    $query  = "SELECT * FROM rft_admin;";
    $result = QL_array($query);
    if(array_key_exists('A', $_GET)){
        if(array_key_exists('ID', $_GET) && $_GET['A'] === 'userDelete'){  
            $q = "DELETE FROM rft_admin where id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);  
            header("Refresh:0; url=index.php?A=userList");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'userInactive'){
            $q = "UPDATE rft_admin SET active = 0 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=userList");
        }
        if(array_key_exists('ID', $_GET)&& $_GET['A'] === 'userActive'){
            $q = "UPDATE rft_admin SET active = 1 WHERE id = :id;";
            executeDML($q, [':id' => $_GET['ID']]);
            header("Refresh:0; url=index.php?A=userList");
        }
    }      
    
?>
<style>
    table { border-collapse: collapse;}
    tr:nth-child(3) { border: solid thin; }
</style>
<center>
    <br><a href="<?=ADMIN_URL?>?A=userAdd">Add new user</a><br><br>
</center>
    <table align="center" style="border: 1px solid;">
        <thead>
            <tr>
                <th>ID</th>
                <th>Username</th>
                <th>E-mail</th>
                <th>Real Name</th>
                <th>Operations</th>
            </tr>           
        </thead>
        <tbody style="text-align: center">
            <?php foreach($result as $row):?>
            <tr>
                <td><?=$row['id'] ?></td>
                <td><?=$row['username'] ?></td>
                <td><?=$row['email'] ?></td>
                <td><?=$row['name'] ?></td>
                <td>
                    <a href="<?=ADMIN_URL?>?A=userEdit&ID=<?=$row['id'] ?>"><img src="../images/edit.png" height="20" width="20"></a>
                    <a href="<?=ADMIN_URL?>?A=userDelete&ID=<?=$row['id']?>"><img src="../images/trash.png" height="20" width="20"></a>
                    <?php if((int)$row['active'] === 1): ?>
                        <a href="<?=ADMIN_URL?>?A=userInactive&ID=<?=$row['id']?>"><img src="../images/open.png" height="20" width="20"></a>
                    <?php else : ?>
                        <a href="<?=ADMIN_URL?>?A=userActive&ID=<?=$row['id']?>"><img src="../images/closed.png"  height="20" width="20"></a>
                    <?php endif; ?>
                </td>
            </tr>
            <?php endforeach;?>
        </tbody>
    </table>
