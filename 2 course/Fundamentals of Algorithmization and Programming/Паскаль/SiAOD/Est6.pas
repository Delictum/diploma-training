Uses Crt;
 
Type TNode = ^Node; {Указатель на узел}
     Node = record
        info : integer;
        left , right : TNode; {Ссылки на левого и правого сыновей}
     end;
 
Var root: TNode;
    n , i , x, key: integer;
    ch:char;
 
Procedure addToTree(var root : TNode; depth , x : integer);
Begin
    if root = Nil then 
    begin
        new(root);
        root^.left := Nil;
        root^.right := Nil;
        root^.info := x;
    end else 
    if (root^.info > x) then
        addToTree(root^.left , depth + 1 , x)
    else
        addToTree(root^.right , depth + 1 , x); 
End;

procedure insert ( var root : TNode ; depth, x : integer );
Begin
   if (root^.info > x) then
        addToTree(root^.left , depth + 1 , x)
    else
        addToTree(root^.right , depth + 1 , x); 
        end;

procedure PrintTr(root : TNode);
begin
  if root = nil then exit;
  PrintTr(root^.Left);
  write(root^.Info, ' ');
  PrintTr(root^.Right);
end;

function find(root:TNode; key:integer; var p, parent:TNode):Boolean;
begin
   p:=root;
   while p<>nil do begin
      if key=p^.info then begin{ узел с таким ключом есть }
         find:=true;
         exit;
      end;
      parent:=p; {запомнить указатель на предка}
      if key<p^.info then
         p := p ^. left {спуститься влево}
      else p := p ^. right ; {спуститься вправо}
   end;
find:=false;
end; 

        procedure del ( var root : TNode ; key : integer );
var
   p : TNode ; {удаляемый узел}
   parent : TNode ; {предок удаляемого узла}
   y : TNode ; {узел, заменяющий удаляемый}
   
function spusk(p:TNode):TNode;
var
   y : TNode ; {узел, заменяющий удаляемый}
   pred:TNode; { предок узла “y”}
begin
   y:=p^.right;
   if y^.left=nil then y^.left:=p^.left {1}
   else {2}
   begin
      repeat
         pred:=y; y:=y^.left;
      until y^.left=nil;
      y^.left:=p^.left; {3}
      pred^.left:=y^.right; {4}
      y^.right:=p^.right; {5}
   end;
   spusk:=y;
end;

begin
   if not find(root, key, p, parent) then {6}
   begin writeln(' такого элемента нет '); exit; end;
   if p^.left=nil then y:=p^.right {7}
   else
      if p^.right=nil then y:=p^.left {8}
      else y:=spusk(p); {9}
   if p=root then root:=y {10}
   else {11}
      if key<parent^.info then
         parent^.left:=y
      else parent^.right:=y;
   dispose(p); {12}
   writeln('Элемент удален!');
end;
 
Begin
    clrscr;
    Writeln('Выберете действие ');
    Writeln('1) Создание дерева поиска');
    Writeln('2) Удаление элемента');
    Writeln('3) Вывод дерева при симметричном обходе');
    Writeln('4) Вставка элемента');
    Writeln('5) Выход');
    repeat{цикл для нашего меню} 
    readln(ch); {ожидаем нажатия клавиши}
    case ch of {выбираем клавишу}
      '1':
        begin
    write('Введите кол-во элементов: ');
    readln(n);
    root := Nil;
    writeln('Введите элементы: ');
    for i := 1 to n do
    begin
        read(x);
        addToTree(root , 0 , x);
    end;
        Writeln('Выберете действие ');
        end;
      '2':
      begin
          write('Элемент для удаления: ');
          readln(key);
          del(root, key);
          Writeln('Выберете действие ');
        end;
      '3':
      begin
    PrintTr(root);
    writeln;
    Writeln('Выберете действие ');
    end;
    '4':
        begin
        writeln('Введите элемент для вставки: ');
        read(x);
        insert(root , 0 , x);
        Writeln('Выберете действие ');
    end;
    end;
  until ch = '5';

End.