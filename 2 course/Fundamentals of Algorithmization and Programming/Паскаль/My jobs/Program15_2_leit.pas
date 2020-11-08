uses GraphABC;
label goback;


begin
  
  LockDrawing;
  goback:
  for var i := 1 to 210 do
  
  begin
    Window.Clear;
    
    Pen.Width := 3;
    MoveTo(120, 305);LineTo(220, 300);
    MoveTo(270, 300);LineTo(370, 305);
    
    
    Pen.Width := 2;
    MoveTo(130, 295);LineTo(220, 290);
    MoveTo(270, 290);LineTo(360, 295);
    
    
    MoveTo(130, 295);LineTo(120, 190);
    MoveTo(360, 295);LineTo(370, 190);
    
    MoveTo(245, 280);LineTo(245, 170);  
    
    MoveTo(130, 295);LineTo(145, 275);
    MoveTo(360, 295);LineTo(345, 275);
    
    MoveTo(120, 190);LineTo(135, 170);
    MoveTo(370, 190);LineTo(355, 170);
    
    MoveTo(145, 275);LineTo(135, 170);
    MoveTo(345, 275);LineTo(355, 170);
    
    MoveTo(145, 275);LineTo(235, 270);
    MoveTo(345, 275);LineTo(255, 270);
    MoveTo(235, 270);LineTo(245, 280);
    MoveTo(255, 270);LineTo(244, 280);
    
    MoveTo(135, 170);LineTo(235, 160);
    MoveTo(355, 170);LineTo(255, 160);
    MoveTo(235, 160);LineTo(245, 170);
    MoveTo(255, 160);LineTo(244, 170);
    
    MoveTo(235, 270);LineTo(235, 160);
    MoveTo(255, 270);LineTo(255, 160);
    
    Pen.Width := 3;
    MoveTo(120, 305);LineTo(105, 180);
    MoveTo(370, 305);LineTo(385, 180);
    
    MoveTo(105, 180);LineTo(127, 178);
    MoveTo(385, 180);LineTo(363, 178);
    
    MoveTo(105, 180);LineTo(127, 178);
    MoveTo(385, 180);LineTo(363, 178);
    
    Pen.Width := 3;
    MoveTo(120, 305);arc(271, 280, 20, -95, -195);
    MoveTo(270, 300);arc(222, 280, 20, 0, -100);
    
    Pen.Width := 1;
    Brush.Color := cllightgray;
    if i < 90 then
    begin

      line(345 - i, 273, 355 - i, 160);
      Brush.Color := cllightgray;
      line(345 - i, 274, 255, 270);
      Brush.Color := cllightgray;
      line(355 - i, 160, 255, 160);
      
    end;
    Brush.Color := cllightgray;
    if (i < 98) and (i > 90) then
    begin
      line(348 - i, 275, 348 - i, 165);
      Brush.Color := cllightgray;
      line(338 - i, 280, 348 - i, 270);
      Brush.Color := cllightgray;
      line(338 - i, 170, 348 - i, 160);      
    end;
    Brush.Color := cllightgray;
    if (i < 106) and (i > 98) then
    begin
    
      line(338 - i, 270, 348 - i, 280);
      Brush.Color := cllightgray;
      line(348 - i, 275, 348 - i, 165);
      Brush.Color := cllightgray;
      line(338 - i, 160, 348 - i, 170);
      
    end;
    Brush.Color := cllightgray;
    if i > 106 then
    begin
      
      line(355 - i, 274, 345 - i, 160);
      Brush.Color := cllightgray;
      line(355 - i, 274, 235, 270);   
      Brush.Color := cllightgray;
      line(345 - i, 160, 235, 160);
      
    end;
    
    
    if i > 209 then
      goto goback;
    Redraw;
    Sleep(1);
  end;
end.