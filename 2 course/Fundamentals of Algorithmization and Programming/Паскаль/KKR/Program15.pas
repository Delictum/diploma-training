program Est;

var
  s: string;
  i, k: integer;

begin
  writeln('������� �����: ');
  readln(s);
  for i := 1 to length(s) - 1 do
  begin
    if (s[i] = '�') and (s[i + 1] = ' ') then k := k + 1;
    if (s[i] = '�') and (s[i + 1] = '.') then k := k + 1;
  end;
  write('���-�� ����: ', k);
end.