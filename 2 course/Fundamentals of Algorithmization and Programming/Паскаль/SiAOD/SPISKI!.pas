program lab1;
 
type
  {Тип основных данных.}
  TData = Integer;
  {Тип, описывающий указатель на элемент.}
  TPElem = ^TElem;
  {Тип, описывающий элемент списка.}
  TElem = record
    Data : TData;   {Основные данные элемента.}
    PNext : TPElem; {Указатель на следующий элемент.}
  end;
  {Тип, описывающий список.}
  TDList = record
    PFirst, PLast : TPElem; {Указатели на первый и на последний элементы списка.}
  end;
 
{Начальная инициализация списка.}
procedure Init(var aL : TDList);
begin
  aL.PFirst := nil;
  aL.PLast := nil;
end;
 
{Освобождение памяти, занятой для элементов списка и инициализация.}
procedure LFree(var aL : TDList);
var
  P, PDel : TPElem;
begin
  P := aL.PFirst;  {Указатель на первый элемент списка.}
  while P <> nil do
  begin
    PDel := P;     {Запоминаем указатель на текущий элемент.}
    P := P^.PNext; {Получаем указатель на следующий элемент.}
    Dispose(PDel); {Освобождаем память, занятую текущим элементом списка.}
  end;
  Init(aL);
end;
 
{Добавление элемента в конец списка.}
procedure Add(var aL : TDList; const aData : TData);
var
  P : TPElem;
begin
  New(P);           {Выделяем паямять для элемента.}
  P^.Data := aData; {Записываем данные.}
  P^.PNext := nil;  {Обнуляем указатель на следующий элемент.}
  if aL.PFirst = nil then {Если список пуст, то новый элемент становится первым элементом списка.}
    aL.PFirst := P
  else {Если список непустой, то новый элемент прикрепляем к последнему элементу списка.}
    aL.PLast^.PNext := P;
  aL.PLast := P; {Новый элемент становится последним элементом списка.}
end;
 
{Распечатка списка.}
procedure LWriteln(const aL : TDList);
var
  P : TPElem;
begin
  P := aL.PFirst; {Указатель на первый элемент списка.}
  if P <> nil then
  repeat
    if P <> aL.PFirst then {Если элемент не первый в списке, то ставим перед ним запятую.}
      Write(', ');
    Write(P^.Data); {Распечатываем данные текущего элемента.}
    P := P^.PNext;  {Получаем указатель на следующий элемент.}
  until P = nil
  else
    Write('Список пуст.');
  Writeln;
end;
 
{Перестановка элемента aP^.PNext на позицию между элементами aPP и aPP^.PNext.}
procedure Recomb(var aL : TDList; var aP, aPP : TPElem);
var
  P : TPElem;
begin
   P := aP^.PNext; {Указатель на элемент, который будем переставлять.}
  if aPP = nil then {Вставка перед первым элементом.}
  begin
    aP^.PNext := P^.PNext;
    P^.PNext := aL.PFirst;
    aL.PFirst := P;
  end
  else                {Вставка между элементами.}
  begin
    aP^.PNext := P^.PNext;
    P^.PNext := aPP^.PNext;
    aPP^.PNext := P;
  end;
end;
 
{Сортировка однонаправленного списка по возрастанию методом вставок.}
procedure SortAsc(var aL : TDList);
var
  P1, P2, PP1, PP2 : TPElem;
begin
  {Если список пуст или содержит только один элемент, то выходим.}
  if aL.PFirst = aL.PLast then
    Exit;
 
  P1 := aL.PFirst; {Указатель на предыдущий элемент.}
  P2 := P1^.PNext; {Указатель на текущий элемент.}
  while P2 <> nil do {Перебор элементов списка, начиная со второго элемента.}
  begin
    {Поиск места вставки в уже отсортированной части списка.}
    PP1 := nil;       {Указатель на предыдущий элемент.}
    PP2 := aL.PFirst; {Указатель на текущий элемент.}
    while PP2^.Data > P2^.Data do {Ограничивающее условие "(PP2 <> P2) and" здесь можно не использовать.}
    begin
      PP1 := PP2;
      PP2 := PP2^.PNext;
    end;
    {Перестановка.}
    if PP1 <> P1 then {Если место вставки отличается от текущей позиции, то выполняем перестановку.}
      Recomb(aL, P1, PP1)
    else
      P1 := P2;
    P2 := P1^.PNext; {Получаем указатель на следующий элемент.}
  end;
end;
 
var
  L : TDList;
  Data : TData;
  i, an, a1 : Integer;
  S : String;
  
begin
  Init(L); {Начальная инициализация списка.}
 
  repeat             
    {Создаём список.}
    Write('Задайте количество элементов: ');
    Readln(an);
    for i := a1 to an do
    begin
      Write('Элемент N ', i, ': ');
      Readln(Data);
      Add(L, Data);
    end;
    Writeln('Задан список:');
    LWriteln(L);
 
    SortAsc(L); {Сортировка списка по возрастанию.}
    Writeln('Список после сортировки:');
    LWriteln(L);
 
    {Освобождение памяти, занятой для элементов списка.}
    LFree(L);
    Writeln('Память, выделенная для списка, освобождена.');
    Readln(S);
  until S <> '';
end.