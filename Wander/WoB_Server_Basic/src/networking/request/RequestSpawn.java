package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Player;
import networking.response.ResponseSpawn;
import utility.DataReader;
import utility.Log;
import java.sql.*;
/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */

public class RequestSpawn extends GameRequest {

    // Data
    private int id;
    private String username;

    // Responses
    private ResponseSpawn responseSpawn;

    public RequestSpawn() {
        responses.add(responseSpawn = new ResponseSpawn());
    }

    @Override
    public void parse() throws IOException {
        username = DataReader.readString(dataInput).trim();
        id = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Log.printf("User: '%s' with '%d' is requsting to spawn...", username, id);
        responseSpawn.setStatus((short) 0); // User succesfully spawned
        responseSpawn.setUsername(username);
        responseSpawn.setId(id);
        Log.printf("User Successfully Spawned");
    }
}
