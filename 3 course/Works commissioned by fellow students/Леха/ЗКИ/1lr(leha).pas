var
  login, password, log, pas: string;
  i, n, rand: integer;
  a: array[1..10] of integer;
  b: array[1..3] of char;
  y: char;

begin
  a[1] := 1; a[2] := 2; a[3] := 3; a[4] := 4; a[5] := 5; a[6] := 6; a[7] := 7; a[8] := 8; a[9] := 9; a[10] := 0;
  b[1] := 'a'; b[2] := 'b'; b[3] := 'c';
  login := 'Log';
  write('Введите длину пароля: ');
  readln(n);
  write('Для усложнения пароля введите y: ');
  readln(y);
  for i := 1 to n do
  begin
    rand := Random(1, 3);
    if (y = 'y') and (rand = 1) then
    begin
      password := password + b[Random(1, 3)];
      continue;
    end;
    password := password + IntToStr(a[Random(1, 10)]);    
  end;
  writeln('Ваш пароль: ', password);
  write('Введите логин: ');
  readln(log);
  write('Введите пароль: ');
  readln(pas);
  if (log = login) and (pas = password) then
    write('Вход выполнен.')
  else
    write('Неверно введены данные.');
end.