program Est;

var
  g, r, x, y: real;

procedure okrug(a, c: real);
begin
  if r > 0 then
  begin
    a := 2 * r * 3.14;
    c := 3.14 * sqr(r);
    write('����� ����������: ', a, '. ������� ����������: ', c, '.');
  end
  else write('���������� �� ����������.');
end;

begin
  write('������� ������: ');
  readln(r);
  okrug(x, y);
end.
