const
  d = 4; {кол-во дисков}
  n = 3; {кол-во пирамид}
  
  Type
  Field=array[1..n, 1..n] of integer;
  
var
  Lab: Field;
  x, y: integer;

procedure PrintLab(Lab: Field);
var
  x, y: integer;
begin
  for x := 1 to n do
  begin
    for y := 1 to n do
      write(lab[x, y]:3);
    writeln;
  end;
  writeln;
end;

procedure GO(LAB: field; x, y: integer);
begin
  if Lab[x, y] = 0 then
  begin
    Lab[x, y] := -1;
    if (x = 1) or (x = n) or (y = 1) or (y = n) then PrintLab(Lab)
    else
    begin
      GO(Lab, x + 1, y);
      GO(Lab, x, y + 1);
      GO(Lab, x - 1, y);
      GO(Lab, x, y - 1);
    end;
    Lab[x, y] := 1;
  end;
end;

begin
  for x:=1 to n do
  for y:=1 to n do
  lab[x,y]:=1;
  
  lab[2,2]:=0;  
  lab[2,3]:=0;
  lab[2,1]:=0;
  
  GO(Lab, 2, 2);
end.