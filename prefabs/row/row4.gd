extends Node2D

var speed = 60
var move_range = 40
var start_x = 0

func _ready():
	start_x = position.x

func _process(delta):
	position.x = start_x - sin(Time.get_ticks_msec() / 600.0) * move_range
