<?php
    require_once '/core/config.php';
    
    function getConnection(){
        $connection = new PDO(DB_TYPE.':host='.DB_HOST.';dbname='.DB_NAME, DB_USER, DB_PASS);
        $connection->exec("SET NAMES 'utf8';");
        return $connection;
    }
    
    function closeConnection($connection){
        $connection = null;
    }
    
    function QL_array($query, $params = []){
        $connection = getConnection();
        $statement = $connection->prepare($query);
        $statement->execute($params);
        $result = $statement->fetchAll();
        $statement->closeCursor();
        closeConnection($connection);
        
        return $result;
    }
    
    function QL_row($query, $params = []){
        $connection = getConnection();
        $statement = $connection->prepare($query);
        $statement->execute($params);
        $result = $statement->fetch();
        $statement->closeCursor();
        closeConnection($connection);
        
        return $result;
    }
    
    function executeDML($query, $params = []){
        $connection = getConnection();
        $statement = $connection->prepare($query);
        $success = $statement->execute($params);
        if(!$success){
            var_dump($statement->errorInfo());
        }
        $statement->closeCursor();
        closeConnection($connection);
        
        return $success;
    }
?>