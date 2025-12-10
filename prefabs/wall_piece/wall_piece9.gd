extends StaticBody2D

@export var out_distance: float = 40   # how far it extends inward
@export var speed: float = 1.5         # how much movement speed
var start_pos: Vector2

func _ready():
	start_pos = position

func _process(delta):
	# Oscillate using a sine wave
	var offset = sin(Time.get_ticks_msec() / 300.0 * speed) * out_distance
	position = start_pos - Vector2(offset, 0)
