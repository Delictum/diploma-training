program Est;

var
  i, k: integer;

begin
  write('������� 1, ���� ��� ����������, � ��������� ������ ������� 0: ');
  repeat
    readln(k);
  until (k = 0) or (k = 1);
  readln(i);
  if (i = 2) and (k = 1) then write('29 ����');
  if (i = 2) and (k = 0) then write('28 ����');
  case i of
    1: write('31 ����');
    3: write('31 ����');
    4: write('30 ����');
    5: write('31 ����');
    6: write('30 ����');
    7: write('31 ����');
    8: write('31 ����');
    9: write('30 ����');
    10: write('31 ����');
    11: write('30 ����');
    12: write('31 ����');
  end;
  
end.