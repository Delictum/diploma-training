uses GraphABC;
label goback;
begin
  
  LockDrawing;
  goback:
  for var i := 1 to 600 do
  begin
    Window.Clear;
    Brush.Color := clBrown;
    Rectangle(10, 10, 630, 470);
    Brush.Color := clwhite;
    Rectangle(20, 20, 620, 460);
    Brush.Color := clgray;
    Rectangle(320, 20, 620 - i, 460);
    line(320, 450, 320, 30, clbrown);
    if i > 599 then
        goto goback;
    Redraw;
    Sleep(1);
  end;
end.