program Est;

var
  s: string;
  i, k: integer;

begin
  writeln('Введите текст: ');
  readln(s);
  for i := 1 to length(s) - 1 do
  begin
    if (s[i] = 'а') and (s[i + 1] = ' ') then k := k + 1;
    if (s[i] = 'а') and (s[i + 1] = '.') then k := k + 1;
  end;
  write('Кол-во слов: ', k);
end.