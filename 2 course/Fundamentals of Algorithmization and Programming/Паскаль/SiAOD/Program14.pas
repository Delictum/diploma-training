var
  i: byte;

procedure Disk(k, a, b: byte);
begin
  if k = 1 then
  begin
    inc(i);
    WriteLn(i, ') ',' ������� ���� �������� � ', a, ' �������� ','->',' �� ', b, ' ��������.');
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
  write('������� ���-�� ������: ');
  ReadLn(n);
  i := 0;
  Disk(n, 1, 3);
end.