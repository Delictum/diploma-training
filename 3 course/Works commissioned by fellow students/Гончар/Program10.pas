//Подсчитать количество чисел, принадлежащих промежутку [a,b] 
//и сумму чисел, стоящих на местах, кратным 3 
var
  mas: array[1..1000, 1..1000] of integer;
  a, b, i, k, s, j: integer;

begin
  k := 0;
  write('Введите промежуток A и B : ');
  readln(a, b);
  
  for i := 1 to 7 do
  begin
    for j := 1 to 7 do
    begin
      mas[i, j] := random(10) + 1;
      write(mas[i, j]:3)
    end;
    writeln;
  end;
  
  for i := 1 to 7 do
    for j := 1 to 7 do
    begin
      if((mas[i, j] >= a) and (mas[i, j] <= b)) then 
        inc(k);
      if(j mod 3 = 0) then
      begin
        s := s + mas[i, j];
      end;
    end;
  writeln('Количество чисел: ', k);
  writeln('Сумма чисел, на позициях в строке, кратных трём: ', s);
end.