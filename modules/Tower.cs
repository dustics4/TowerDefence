using Godot;
using System;
using System.Numerics;

public partial class Tower : Node2D
{
	private float[,] _coordsHead = 
	{
		{ 22.952f, 83.271f },  { 28.385f, 98.623f },
        { 53.168f, 107.647f }, { 72.998f, 107.647f },
        { 99.546f, 98.623f },  { 105.048f, 83.271f },
        { 105.029f, 55.237f }, { 110.740f, 47.082f },
        { 102.364f, 36.104f }, { 94.050f, 40.940f },
        { 85.189f, 34.445f },  { 85.963f, 24.194f },
        { 73.507f, 19.930f },  { 68.883f, 28.936f },
        { 59.118f, 28.936f },  { 54.494f, 19.930f },
        { 42.039f, 24.194f },  { 42.814f, 34.445f },
        { 33.951f, 40.940f },  { 25.637f, 36.104f },
        { 17.262f, 47.082f },  { 22.973f, 55.237f }
	};

	private float[,] _coordsMouth = 
	{
		{ 22.817f, 81.100f }, { 38.522f, 82.740f },
    	{ 39.001f, 90.887f }, { 54.465f, 92.204f },
    	{ 55.641f, 84.260f }, { 72.418f, 84.177f },
    	{ 73.629f, 92.158f }, { 88.895f, 90.923f },
    	{ 89.556f, 82.673f }, { 105.005f, 81.100f }
	};

	private Godot.Vector2[] _head;
	private Godot.Vector2[] _mouth;
	private float _mouthWidth = 4.4f;
	private Godot.Vector2[] FloatArrayToVector2Array(float[,] coords)
	{
		int size = coords.GetUpperBound(0);
		Godot.Vector2[] array = new Godot.Vector2[size + 1];
		for(int i = 0; i <= size; i++){
			array[i] = new Godot.Vector2(coords[i, 0], coords[i, 1]);
		}
		return array;
	}

    public override void _Draw()
    {
		Color white = Colors.White;
		Color godotBlue = new Color("478cbf");
		DrawPolygon(_head, new Color[]{godotBlue});
		DrawPolyline(_mouth, white, _mouthWidth);	
    }
	
    public override void _Ready()  // Called when the node enters the scene tree for the first time.
	{
		_head = FloatArrayToVector2Array(_coordsHead);
		_mouth = FloatArrayToVector2Array(_coordsMouth);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		QueueRedraw();
	}
}
