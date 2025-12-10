extends Node

var time_left := 60  # 60 seconds (1 minute)

func _ready():
	$TickTimer.start()
	update_label()

func _on_TickTimer_timeout():
	time_left -= 1
	update_label()

	if time_left <= 0:
		$TickTimer.stop()
		print("Timer finished!")

func update_label():
	$Label.text = str(time_left)
	


func _on_timeout() -> void:
	pass # Replace with function body.
