extends CharacterBody2D
const SPEED = 300.0
const JUMP_VELOCITY = -400.0

var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func  _enter_tree():
	set_multiplayer_authority(str(name).to_int())
	pass

func _physics_process(delta):
	
	if is_multiplayer_authority():
		if not is_on_floor():
			velocity.y += gravity * delta
		if Input.is_action_just_pressed("ui_up") and is_on_floor():
			velocity.y = JUMP_VELOCITY
		var direction = Input.get_axis("ui_left", "ui_right")
		if direction:
			velocity.x = direction * SPEED
		else:
			velocity.x = move_toward(velocity.x, 0, SPEED)
		move_and_slide()
