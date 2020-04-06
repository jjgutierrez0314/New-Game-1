package networking.response;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Player;
import networking.response.ResponseMovement;
import utility.DataReader;
import utility.GamePacket;
import utility.Log;

public class ResponseMovement extends GameResponse {

    private Player player;

    public ResponseMovement() { responseCode = Constants.SMSG_MOVEMENT; }

    @Override
    public byte[] constructResponseInBytes() {
       GamePacket packet = new GamePacket(responseCode);
       packet.addInt32(player.getX());
       packet.addInt32(player.getY());
       return packet.getBytes();
    }

    public void setPlayer(Player player) { this.player = player; }
}
