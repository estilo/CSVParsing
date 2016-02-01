<?php

/**
 * DatabaseConnect short summary.
 *
 * DatabaseConnect description.
 *
 * @version 1.0
 * @author Sandeepan Kundu
 */
require ("configuration.php");
class DatabaseConnect
{
    private $db;
    function __construct()
    {
        $db  = mysqli(DB_HOST,DB_USER,DB_PASSWORD);//or die('Could not connect to MySQL server.');
        //if($db->connect_errno > 0){
        //if($db->connect_error > 0){
        if($db->mysqli_connect_error() ){
            die('Unable to connect to database [' . $db->mysqli_connect_error() . ']');
            //die('Unable to connect to database [' . $db->connect_error . ']');
        }
        //$__dblink  = mysqli_connect(DB_HOST,DB_USER,DB_PASSWORD) or die('Could not connect to MySQL server.');
        //mysqli_select_db(DB_DATABASE, $__dblink);
    }

    public function executeQuery($sql){
        //return mysqli_query( $__dblink, $queryString ) or die ("Error in query: $queryString. ".mysql_error());
        //return mysqli_query( $__dblink, $sql )or trigger_error($link->error."[ $sql]");
        /*
        $result =  mysqli_query( $__dblink, $sql );
        if (!$result) {
            throw new Exception(mysqli_error($link)."[ $sql]");
        }
        return $result;
        */
        if (!mysqli_query($db, $sql)) {
            printf("Errormessage: %s\n", mysqli_error($db));
        }

        //return mysql_query($query)or die ("Error in query: $query. ".mysql_error());
            /*'SELECT * FROM database_name.table_name');*/
    }
    
}

?>