unit Niger1;

interface
 
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

procedure Init(var aL : TDList);
procedure Add(var aL : TDList; const aData : TData);
procedure LWriteln(const aL : TDList);
procedure LFree(var aL : TDList);
implementation

procedure Init(var aL : TDList);
begin
  aL.PFirst := nil;
  aL.PLast := nil;
end;

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

end.
  