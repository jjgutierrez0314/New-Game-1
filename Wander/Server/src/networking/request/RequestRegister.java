package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseRegister;
import utility.DataReader;
import utility.Log;

//SQL
import java.sql.*;

public class RequestRegister extends GameRequest {

    // Data
    private String version;
    private String user_id;
    private String password;
    // Responses
    private ResponseRegister responseRegister;

    public RequestRegister() {
        responses.add(responseRegister = new ResponseRegister());
    }

    @Override
    public void parse() throws IOException {
        version = DataReader.readString(dataInput).trim();
        user_id = DataReader.readString(dataInput).trim();
        password = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        // SQL
        String url = "jdbc:mysql://wanderdb.c4p7z07xl4sc.us-east-1.rds.amazonaws.com:3306";
        String user = "root";
        String sqlpw = "awesomeganbold";
        String select = "SELECT * FROM wander.Users;";
        Boolean checkUser = false;

        try (Connection con = DriverManager.getConnection(url, user, sqlpw);
             PreparedStatement sql_statement = con.prepareStatement(select);

             ResultSet result = sql_statement.executeQuery()) {

            while(result.next() && !checkUser){
                //get data from db
                String username = result.getString("username");
                if(user_id.equals(username)){
                    System.out.println("UserName: " + user_id + " is taken...");
                    checkUser = true;
                }
            }
        } catch (SQLException ex) {
            System.out.println("error");
        }

        if(!checkUser){
            try(
                Connection connect = DriverManager.getConnection(url, user, sqlpw);
                PreparedStatement sql_statement = connect.prepareStatement( "INSERT INTO  wander.Users values(default,?,?)")){

                sql_statement.setString(1,user_id);
                sql_statement.setString(2,password);
                sql_statement.executeUpdate();
                connect.close();

                Log.printf("'%s' is successfully registered!", user_id);
                responseRegister.setStatus((short) 0);


            } catch (SQLException ex) {
                System.out.println("error");
            }
            //  PreparedStatement add = con.prepareStatement(addUser);
            //  add.executeQuery();
        } else {
            responseRegister.setStatus((short) 1);
        }
    }

}
