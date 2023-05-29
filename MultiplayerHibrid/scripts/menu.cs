using Godot;
using System;

public partial class menu : Control
{
	public string IpPadrao="127.0.0.1";
	public int porta=6007;
	public ENetMultiplayerPeer Par=new ENetMultiplayerPeer();
	public PackedScene Pl;
	//Nodes
	public Node2D Mundo;

	 public override void _Ready(){
		Mundo=GetNode<Node2D>("mundo");
		Pl=ResourceLoader.Load<PackedScene>("res://scenes/jogador.tscn");
		
	 }

	private void CriarServidor(){
		Par.CreateServer(porta);
		Multiplayer.MultiplayerPeer=Par;
		AdicionarPlayer(Multiplayer.GetUniqueId());
		
		//Multiplayer.ConnectedToServer += AdicionarPlayer;
	}

	private void EntrarServidor(){
		Par.CreateClient(IpPadrao,porta);
		Multiplayer.MultiplayerPeer=Par;
	}

	private void AdicionarPlayer(int id){
		var PlayerNew=Pl;

		var playernode = (jogador)Pl.Instantiate();
		playernode.Name=id.ToString();
		Mundo.AddChild(playernode);
	
	}
	private void RemoverPlayer(int id){
		GD.Print("jogador saiu");
	}


}
