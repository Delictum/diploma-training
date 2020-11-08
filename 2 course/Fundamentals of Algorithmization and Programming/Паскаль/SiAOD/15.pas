program ferzi;

type
  mas = array [1..15, 1..15] of integer;

var
  a: mas;   
  {матрица, описывающа€ положение шахматной доски}
  i, j, n: integer;
  k: longint;
  t: text;
  vyvod: boolean;

procedure Fill_F(x, y: integer; var a: mas);
 {x, y*Ч координаты вставки ферз€}
var
  i, j: integer;
begin
  for i := 1 to n do
  begin
    a[x, i] := 1; {строка, где будет сто€ть ферзь*ЧЂпод боемї}
    a[i, y] := 1;     {столбец, где будет сто€ть ферзь*ЧЂпод боемї}
  end;
  i := x - 1;     {переходим в левую верхнюю клетку по диагонали}
  j := y - 1;     {от (x,y)}
  while (i <> 0) and (j <> 0) do
  begin
    a[i, j] := 1;   {помечаем диагональ слева и вверх от (x,y) }
    dec(i);
    dec(j);
  end;
  i := x + 1;      {переходим в правую нижнюю клетку по диагонали от (x,y)}
  j := y + 1;
  while (i <> n + 1) and (j <> n + 1) do
  begin
    a[i, j] := 1;    {помечаем диагональ справа и вниз от (x,y) }
    inc(i);
    inc(j);
  end;
  i := x - 1;      {переходим в правую верхнюю клетку}
  j := y + 1;
  while (i <> 0) and (j <> n + 1) do
  begin
    a[i, j] := 1;    {помечаем диагональ справа и вверх от (x,y)}
    dec(i);
    inc(j);
  end;
  i := x + 1;   {переходим в левую нижнюю клетку от (x,y)}
  j := y - 1;
  while (i <> n + 1) and (j <> 0) do
  begin
    a[i, j] := 1;    {помечаем диагональ слева и вниз от (x,y)}
    inc(i);
    dec(j);
  end;
  a[x, y] := 0;    {ставим ферз€ на место (x,y)}
end;

procedure Set_F(x: integer; a: mas);
{x*Ч строка, куда добавл€ем ферз€}
var
  i, j: integer;
  b: mas;
begin
  if (x = n + 1) and (vyvod = true) then {если все ферзи расставлены}
  begin
    for i := 1 to n do       {выводим матрицу расстановки}
    begin
      for j := 1 to n do
        write(a[i, j]:3);
      writeln;
    end;
    writeln;
    vyvod:=false;
  end;

  if x = n + 1 then {если все ферзи расставлены}
  begin
    for i := 1 to n do       {выводим матрицу расстановки}
    begin
      for j := 1 to n do
        write(t, a[i, j]:3);
      writeln(t);
    end;
    writeln(t);
    inc(k);{наращиваем счетчик вариантов расстановки}
  end
  
  else        {в противном случае}
    for i := 1 to n do       {ищем в строке}
      if a[x, i] = 0 then      {первую свободную клетку}
      begin
        b := a;        {копируем матрицу a в матрицу b}
        Fill_F(x, i, b);  {устанавливаем ферз€ в i-й столбец строки x}
        Set_F(x + 1, b);      {вызываем процедуру вставки ферз€ в следующую x+1-ю строку измененной матрицы b}
      end;
end;

begin
  writeln('«а 0 обозначен ферзь, за 1 свободные клетки. ѕерва€ расстановка:');
  writeln;
  vyvod:=true;
  assign(t, '15.txt');
  rewrite(t);
  n := 8;
  k := 0;      {количество вариантов расстановок равно 0}
  for i := 1 to n do
    for J := 1 to n do
      a[i, j] := 0;       {все клетки матрицы свободны}
  Set_F(1, a);        {вызываем рекурсивную процедуру установки ферз€ (сначала устанавливаем первого ферз€ на свободную доску)}
  writeln(' ол-во возможных расстановок: ', k);    {выводим ответ*Ч число вариантов расстановки}
  close(t);
end.