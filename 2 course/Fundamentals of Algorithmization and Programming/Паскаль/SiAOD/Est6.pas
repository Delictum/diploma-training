Uses Crt;
 
Type TNode = ^Node; {��������� �� ����}
     Node = record
        info : integer;
        left , right : TNode; {������ �� ������ � ������� �������}
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
      if key=p^.info then begin{ ���� � ����� ������ ���� }
         find:=true;
         exit;
      end;
      parent:=p; {��������� ��������� �� ������}
      if key<p^.info then
         p := p ^. left {���������� �����}
      else p := p ^. right ; {���������� ������}
   end;
find:=false;
end; 

        procedure del ( var root : TNode ; key : integer );
var
   p : TNode ; {��������� ����}
   parent : TNode ; {������ ���������� ����}
   y : TNode ; {����, ���������� ���������}
   
function spusk(p:TNode):TNode;
var
   y : TNode ; {����, ���������� ���������}
   pred:TNode; { ������ ���� �y�}
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
   begin writeln(' ������ �������� ��� '); exit; end;
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
   writeln('������� ������!');
end;
 
Begin
    clrscr;
    Writeln('�������� �������� ');
    Writeln('1) �������� ������ ������');
    Writeln('2) �������� ��������');
    Writeln('3) ����� ������ ��� ������������ ������');
    Writeln('4) ������� ��������');
    Writeln('5) �����');
    repeat{���� ��� ������ ����} 
    readln(ch); {������� ������� �������}
    case ch of {�������� �������}
      '1':
        begin
    write('������� ���-�� ���������: ');
    readln(n);
    root := Nil;
    writeln('������� ��������: ');
    for i := 1 to n do
    begin
        read(x);
        addToTree(root , 0 , x);
    end;
        Writeln('�������� �������� ');
        end;
      '2':
      begin
          write('������� ��� ��������: ');
          readln(key);
          del(root, key);
          Writeln('�������� �������� ');
        end;
      '3':
      begin
    PrintTr(root);
    writeln;
    Writeln('�������� �������� ');
    end;
    '4':
        begin
        writeln('������� ������� ��� �������: ');
        read(x);
        insert(root , 0 , x);
        Writeln('�������� �������� ');
    end;
    end;
  until ch = '5';

End.