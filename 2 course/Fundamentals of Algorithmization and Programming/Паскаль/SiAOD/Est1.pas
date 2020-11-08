uses Niger1;
var
  L1, L2, L3: TDList;
  Data: TData;
  i, p, a, b, c, d, arm: Integer;

begin
  Init(L1); {Начальная инициализация списка.}        
    {Создаём список.}
  for i := 10 to 99 do
  begin
    p := i;
    arm := 0;
    begin
      a := p mod 10;
      b := p div 10;
      arm := sqr(a) + sqr(b);
    end;
    if arm = i then 
    begin
      Data := i;
      Add(L1, Data);
    end;
  end;
  Writeln('Задан список 1:');
  LWriteln(L1);
  
  Init(L2); {Начальная инициализация списка.}        
    {Создаём список.}
  for i := 100 to 999 do
  begin
    p := i;
    arm := 0;
    begin
      a := p mod 10;
      b := p div 10 mod 10;
      c := p div 100;
      arm := c * c * c + b * b * b + a * a * a;
    end;
    if arm = i then 
    begin
      Data := i;
      Add(L2, Data);
    end;
  end;
  Writeln('Задан список 2:');
  LWriteln(L2);

  Init(L3); {Начальная инициализация списка.}        
    {Создаём список.}
  for i := 1000 to 9999 do
  begin
    p := i;
    arm := 0;
    begin
      a := p mod 10;
      b := p div 10 mod 10;
      c := p div 1000;
      d := p div 100 mod 10;
      arm := c * c * c * c + b * b * b * b + a * a * a * a + d * d * d * d;
    end;
    if arm = i then 
    begin
      Data := i;
      Add(L3, Data);
    end;
  end;
  Writeln('Задан список 3:');
  LWriteln(L3);

end.