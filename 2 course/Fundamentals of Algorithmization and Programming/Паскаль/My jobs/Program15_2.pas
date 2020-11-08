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
    Rectangle(320, 20, 620, 460);
    line(320, 450, 320, 30, clbrown);
    if i<25 then 
    begin
    line(610-i,25+i,610-i,455+i);
    line(610-i,455+i,500-i,455);
    line(320,455,500-i,455);    
    line(610-i,25+i,500-i,25);
    line(320,25,500-i,25); 
    end;
    if (i>25) and (i<50) then 
    begin
    line(610-i,75-i,610-i,505-i);
    line(610-i,505-i,500-i,455);
    line(320,455,500-i,455);    
    line(610-i,75-i,500-i,25);
    line(320,25,500-i,25);   
    end;
    if (i>50) and (i<180) then 
    begin
    line(610-i,25,610-i,455);
    line(610-i,455,500-i,455);
    line(320,455,500-i,455);    
    line(610-i,25,500-i,25);
    line(320,25,500-i,25); 
    end;    
    if (i>180) then 
    begin
    line(610-i,25,610-i,455);
    line(610-i,455,320,455);
    line(610-i,25,320,25);
    end;  

    if i > 599 then
        goto goback;
    Redraw;
    Sleep(1);
  end;
end.