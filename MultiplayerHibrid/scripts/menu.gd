extends Control
var ippadrao="127.0.0.1"
var porta=6007

var jogadoresArray=[]
var pl=preload("res://scenes/jogador.tscn")#cena do player
var peer=ENetMultiplayerPeer.new()
func _ready():
	pass
	

func adicionarPlayer(id):
	var playerNew=pl.instantiate()
	playerNew.name=str(id)
	$mundo.add_child(playerNew)
	print("jogador novo entrou")
	pass

func removePlayer(id):
	print("jogador saiu")
	pass

func serverDelete():
	print("servidor caiu")
	pass


func _on_criar_servidor_pressed():
	peer.create_server(porta)
	multiplayer.set_multiplayer_peer(peer)
	
	adicionarPlayer(multiplayer.get_unique_id())
	multiplayer.peer_connected.connect(adicionarPlayer)
	multiplayer.peer_disconnected.connect(removePlayer)
	multiplayer.server_disconnected.connect(serverDelete)
	pass # Replace with function body.


func _on_entrar_servidor_pressed():
	peer.create_client(ippadrao,porta)
	multiplayer.set_multiplayer_peer(peer)
	pass # Replace with function body.
