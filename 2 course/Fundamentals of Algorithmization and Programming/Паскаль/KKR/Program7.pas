program Est;

var
  i: integer;

begin
  write('������� ���: ');
  readln(i);
  if (i mod 4 = 0) and (i mod 100 = 0) and (i mod 400 <> 0) then write('� ���� 366 ����') else write('� ���� 365 ����');
end.