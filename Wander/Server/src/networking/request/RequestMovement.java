package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Player;
import networking.response.ResponseMovement;
import utility.DataReader;
import utility.Log;


public class RequestMovement extends GameRequest {

    private int x, y;

    private ResponseMovement responseMovement;

    public RequestMovement() { responses.add(responseMovement = new ResponseMovement()); }

    @Override
    public void parse() throws IOException {
        x = DataReader.readInt(dataInput);
        y = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = GameServer.getInstance().getActivePlayer(100);
        player.setX(x);
        player.setY(y);
        responseMovement.setPlayer(player);
        Log.printf("Player coordinates - X: " + player.getX() + " Y: " + player.getY());
    }
}
