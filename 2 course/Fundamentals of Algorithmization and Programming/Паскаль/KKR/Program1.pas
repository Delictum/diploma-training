program Est;

var
  i, j, s: real;
  a: char;

begin
  write('������� ��� �����: ');
  readln(i);
  readln(j);
  write('������� ���� ��������: ');
  readln(a);
  if a = '+' then s := i + j;
  if a = '-' then s := i - j;
  if a = '*' then s := i * j;
  if a = '/' then s := i / j;
  write('���������� ���������: ', s);
end.