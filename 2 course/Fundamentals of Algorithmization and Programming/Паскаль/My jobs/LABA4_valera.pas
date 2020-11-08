program Est;

var
  
  i, k, n, a: integer;

begin
  writeln('Введите число: ');
  readln(n);
  writeln('Простые числа ниже заданного: ');
  write('1 ');
  while k < n - 1 do
  begin
    for k := 1 to n - 1 do 
    begin
      a := 0;
      for i := 1 to k do 
      begin
        if k mod i = 0 then inc(a);
      end;     
      if a = 2 then write(k, ' ')
    end;
  end;
end.