var
  i: byte;

procedure Disk(k, a, b: byte);
begin
  if k = 1 then
  begin
    inc(i);
    WriteLn(i, ') ',' Верхний диск кладется с ', a, ' пирамиды ','->',' на ', b, ' пирамиду.');
  end
  else
  begin
    Disk(k - 1, a, 6 - a - b);
    Disk(1, a, b);
    Disk(k - 1, 6 - a - b, b);
  end
end;

var
  n: byte;

begin
  write('Введите кол-во дисков: ');
  ReadLn(n);
  i := 0;
  Disk(n, 1, 3);
end.