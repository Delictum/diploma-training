Var str : string;
  i, count1, count0 : integer;
Begin
  write('������� ������ �� 0 � 1: ');
  readln(str);
  count1 := 0;
  count0 := 0;
  for i := 1 to str.Length do
  begin
    if (str[i] = '1') then
      count1 += 1;
    if (str[i] = '0') then
      count0 += 1;
  end;
  if (count1 > count0) then
    writeln('������ ������ - ' + count1)
  else
    writeln('������ ����� - ' + count0);
end.