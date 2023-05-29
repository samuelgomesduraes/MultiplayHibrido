using Godot;
using System;

public partial class jogador : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public AnimatedSprite2D Animacao;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _EnterTree(){
		SetMultiplayerAuthority(Name.ToString().ToInt());
	}

	public override void _Ready(){
		Animacao=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		if(IsMultiplayerAuthority()){
			Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			Animacao.Play("run");
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			Animacao.Play("default");
		}
		
		flipar();

		Velocity = velocity;
		MoveAndSlide();
		}
		
	}
	
	private void flipar(){
			if(Velocity.X < 0){
				Animacao.FlipH=true;
			}
			else
			{
				Animacao.FlipH=false;	
			}
		}
}
