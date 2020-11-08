unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls,
  Vcl.Imaging.GIFImg, Vcl.ExtCtrls, Vcl.Buttons, Vcl.Imaging.jpeg,
  Vcl.Imaging.pngimage, Data.DB, Vcl.Grids, Vcl.DBGrids, Vcl.Menus, ShellAPI;

type
  TFormTest = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    Image2: TImage;
    Image3: TImage;
    Image4: TImage;
    Image5: TImage;
    Image6: TImage;
    Image7: TImage;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    RadioButton4: TRadioButton;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Image8: TImage;
    Image9: TImage;
    TabSheet6: TTabSheet;
    TabSheet7: TTabSheet;
    TabSheet8: TTabSheet;
    TabSheet9: TTabSheet;
    TabSheet10: TTabSheet;
    Image10: TImage;
    Image11: TImage;
    Image12: TImage;
    Image13: TImage;
    Image14: TImage;
    Image15: TImage;
    Image16: TImage;
    Image17: TImage;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    ComboBox3: TComboBox;
    Image18: TImage;
    Image19: TImage;
    Image20: TImage;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Image21: TImage;
    Image22: TImage;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    Image23: TImage;
    Image25: TImage;
    Image26: TImage;
    Edit1: TEdit;
    Image27: TImage;
    ListBox2: TListBox;
    ComboBox4: TComboBox;
    ListBox3: TListBox;
    ListBox4: TListBox;
    Image28: TImage;
    Image29: TImage;
    TrackBar1: TTrackBar;
    Image30: TImage;
    Label16: TLabel;
    Image32: TImage;
    Label1: TLabel;
    Label2: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label17: TLabel;
    Label14: TLabel;
    Label18: TLabel;
    RadioButton5: TRadioButton;
    RadioButton6: TRadioButton;
    RadioButton7: TRadioButton;
    RadioButton8: TRadioButton;
    Image1: TImage;
    Image24: TImage;
    Label7: TLabel;
    DBGrid1: TDBGrid;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    N2: TMenuItem;
    procedure Image6Click(Sender: TObject);
    procedure Image2Click(Sender: TObject);
    procedure Image3Click(Sender: TObject);
    procedure Image5Click(Sender: TObject);
    procedure Image4Click(Sender: TObject);
    procedure Image8Click(Sender: TObject);
    procedure Image9Click(Sender: TObject);
    procedure Image10Click(Sender: TObject);
    procedure Image11Click(Sender: TObject);
    procedure Image12Click(Sender: TObject);
    procedure Image14Click(Sender: TObject);
    procedure Image13Click(Sender: TObject);
    procedure Image15Click(Sender: TObject);
    procedure Image16Click(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
    procedure ComboBox3Change(Sender: TObject);
    procedure Image17Click(Sender: TObject);
    procedure Image18Click(Sender: TObject);
    procedure Image19Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Image21Click(Sender: TObject);
    procedure CheckBox1Click(Sender: TObject);
    procedure CheckBox2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Image23Click(Sender: TObject);
    procedure Image25Click(Sender: TObject);
    procedure Image27Click(Sender: TObject);
    procedure ComboBox4Change(Sender: TObject);
    procedure ListBox2DblClick(Sender: TObject);
    procedure ListBox4DblClick(Sender: TObject);
    procedure ListBox3DblClick(Sender: TObject);
    procedure Image29Click(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure Helper1Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure N2Click(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormTest: TFormTest;
  StartingPoint : TPoint;
  Otvet:integer;
  O1, O2, O3, O4, O5, O6, O7:boolean;
  Ot, list, stro3, stro4:string;

implementation

{$R *.dfm}

uses Unit2, Unit1, Unit3;

procedure TFormTest.ListBox2DblClick(Sender: TObject);
Var n:integer;
begin
if ListBox3.Visible=true then
if ListBox3.Items.Count <4 then
begin
n:=ListBox2.ItemIndex;
if (n=-1)or(n>ListBox2.Count-1) then Exit;
ListBox3.Items.Add(ListBox2.Items.Strings[n]);
ListBox2.Items.Delete(n);
end;
if ListBox4.Visible=true then
if ListBox4.Items.Count <4 then
begin
n:=ListBox2.ItemIndex;
if (n=-1)or(n>ListBox2.Count-1) then Exit;
ListBox4.Items.Add(ListBox2.Items.Strings[n]);
ListBox2.Items.Delete(n);
End;
end;

procedure TFormTest.ListBox3DblClick(Sender: TObject);
Var n:integer;
begin
n:=ListBox3.ItemIndex;
if (n=-1)or(n>ListBox2.Count-1) then Exit;
ListBox2.Items.Add(ListBox3.Items.Strings[n]);
ListBox3.Items.Delete(n);
end;

procedure TFormTest.ListBox4DblClick(Sender: TObject);
Var n:integer;
begin
n:=ListBox4.ItemIndex;
if (n=-1)or(n>ListBox4.Count-1) then Exit;
ListBox2.Items.Add(ListBox4.Items.Strings[n]);
ListBox4.Items.Delete(n);
end;

procedure TFormTest.N2Click(Sender: TObject);
begin
  FormTest.Hide;
  FormDinozavr.Show;
end;

procedure TFormTest.N4Click(Sender: TObject);
begin
  LogOut.Close;
  LogReg.Close;
  FormDinozavr.Close;
end;

procedure TFormTest.TrackBar1Change(Sender: TObject);
begin
    Image24.Height := TrackBar1.Position;
    Image24.Width  := TrackBar1.Position;
    Image24.Left   := ClientWidth div 2 - Image24.Width div 2;
    Image24.Top    := ClientHeight div 2 + 30 - Image24.Height div 2;
end;

procedure TFormTest.Button1Click(Sender: TObject);
begin
O5:=false;
end;

procedure TFormTest.Button2Click(Sender: TObject);
begin
O5:=false;
end;

procedure TFormTest.Button3Click(Sender: TObject);
begin
O5:=false;
end;

procedure TFormTest.Button4Click(Sender: TObject);
begin
O5:=true;
end;

procedure TFormTest.CheckBox1Click(Sender: TObject);
begin
O6:=true;
end;

procedure TFormTest.CheckBox2Click(Sender: TObject);
begin
O7:=true;
end;

procedure TFormTest.ComboBox1Change(Sender: TObject);
var i:integer;
begin
  i:=combobox1.ItemIndex;
  case i of
  0: ;
  1: O2:=true;
  2: ;
  3: ;
  end;
end;

procedure TFormTest.ComboBox2Change(Sender: TObject);
var i:integer;
begin
  i:=combobox2.ItemIndex;
  case i of
  0: O3:=true;
  1: ;
  2: ;
  3: ;
  end;
end;

procedure TFormTest.ComboBox3Change(Sender: TObject);
var i:integer;
begin
  i:=combobox3.ItemIndex;
  case i of
  0: O4:=true;
  1: ;
  2: ;
  3: ;
  end;
end;

procedure TFormTest.ComboBox4Change(Sender: TObject);
var i:integer;
begin
  i:=combobox4.ItemIndex;
  case i of
  0: begin
  ListBox3.Visible:=true;
  ListBox4.Visible:=false;
  end;
  1: begin
  ListBox3.Visible:=false;
  ListBox4.Visible:=true;
  end;
  end;
end;

procedure TFormTest.Helper1Click(Sender: TObject);
begin
  ShellExecute (LogReg.Handle, nil, 'iexplore', 'https://https://thedrakoneragoni.wixsite.com/helper/', nil, SW_RESTORE);
end;

procedure TFormTest.Image10Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 3;
end;

procedure TFormTest.Image11Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 4;
if O5=true then Otvet:=Otvet+1;
end;

procedure TFormTest.Image12Click(Sender: TObject);
begin
if O6=true then Otvet:=Otvet+1;
if O7=true then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 5;
end;

procedure TFormTest.Image13Click(Sender: TObject);
begin
if RadioButton7.Checked = true then
Otvet:=Otvet+2;
PageControl1.ActivePageIndex := 6;
end;

procedure TFormTest.Image14Click(Sender: TObject);
var i: integer;
begin
if edit1.Text='�����' then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 7;
end;

procedure TFormTest.Image15Click(Sender: TObject);
var i: integer;
begin
if listBox2.Items.Count=0 then
begin
for i := 1 to 4 do
with ListBox3 do
  begin
    stro3:=stro3+Items[i-1];
  end;
  for i := 1 to 4 do
with ListBox4 do
  begin
    stro4:=stro4+Items[i-1];
  end;
  if ('������������ �������� ��������� ��������� '=stro4) and ('�������� ��������� ��������� ��������� '=stro3) then Otvet:=Otvet+5;
  PageControl1.ActivePageIndex := 8;
end
else
ShowMessage('Fill out the field');
end;

procedure TFormTest.Image16Click(Sender: TObject);
begin
if (trackBar1.Position>230) and (trackBar1.Position<280) then
Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 9;
Ot:=inttostr(Otvet);
Label7.Caption:=Label7.Caption+ot;
if Otvet<>1 then
label7.Caption:=Label7.Caption+' ������.'
else
label7.Caption:=Label7.Caption+' ����.';

if (Otvet<=12) and (Otvet>=6) then
begin
label16.Caption:='�� ������.';
end;
if Otvet>12 then
begin
label16.Caption:='������� ����������.';
end;
if Otvet<6 then
begin
label16.Caption:='���� ������ ������.';
end;
image32.Visible:=true;

      if IntToStr(Otvet) > VarToStr(LogReg.SQLQuery1.FieldValues['Score']) then
        begin
          ShowMessage('�� ������ ���� ������!');
          LogReg.SQLQuery1.Close;
           LogReg.SQLQuery1.SQL.Clear;
            LogReg.SQLQuery1.SQL.Add('UPDATE Users Set Score = ' + IntToStr(Otvet));
             LogReg.SQLQuery1.SQL.Add(' WHERE Name = "' + bufName + '"');
              LogReg.SQLQuery1.ExecSQL;
        end;
      LogReg.ClientDataSet1.Active := false;
       LogReg.SQLQuery1.Close;
        LogReg.SQLQuery1.SQL.Clear;
         LogReg.SQLQuery1.SQL.Add('SELECT * FROM Users ORDER BY  Score DESC LIMIT 5');
          LogReg.SQLQuery1.Open;
           LogReg.ClientDataSet1.Active := true;
end;

procedure TFormTest.Image17Click(Sender: TObject);
begin
if O2=true then Otvet:=Otvet+1;
if O3=true then Otvet:=Otvet+1;
if O4=true then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 3;
end;

procedure TFormTest.Image18Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
if O1=true then Otvet:=Otvet-1;
end;

procedure TFormTest.Image19Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 2;
if O2=true then Otvet:=Otvet-1;
if O3=true then Otvet:=Otvet-1;
if O4=true then Otvet:=Otvet-1;
end;

procedure TFormTest.Image21Click(Sender: TObject);
begin
if O5=true then  otvet:=Otvet-1;
PageControl1.ActivePageIndex := 3;
end;

procedure TFormTest.Image23Click(Sender: TObject);
begin
if O6=true then  otvet:=Otvet-1;
if O7=true then  otvet:=Otvet-1;
PageControl1.ActivePageIndex := 4;
end;

procedure TFormTest.Image25Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 5;
if List='Punk is alive, still alive punks, so Punk will never die.' then
Otvet:=Otvet-2;
end;

procedure TFormTest.Image27Click(Sender: TObject);
begin
if edit1.Text='Grunge' then Otvet:=Otvet-1;
PageControl1.ActivePageIndex := 6;
end;

procedure TFormTest.Image29Click(Sender: TObject);
begin
if ('������ � ��� ������� Sex Pistols ���� '=stro4) and ('Distemper ������ ����������� ������� Black Flag '=stro3)
then Otvet:=Otvet-5;
PageControl1.ActivePageIndex := 7;
end;

procedure TFormTest.Image2Click(Sender: TObject);
begin
if O1=true then Otvet:=Otvet-1;
Label3.Visible:=True;
Label4.Visible:=False;
Label5.Visible:=False;
Label6.Visible:=False;
end;

procedure TFormTest.Image3Click(Sender: TObject);
begin
Label4.Visible:=False;
Label3.Visible:=False;
Label5.Visible:=True;
Label6.Visible:=False;
Otvet:=Otvet+1;
O1:=true;
end;

procedure TFormTest.Image4Click(Sender: TObject);
begin
Label5.Visible:=False;
Label3.Visible:=False;
Label4.Visible:=False;
Label6.Visible:=True;
end;

procedure TFormTest.Image5Click(Sender: TObject);
begin
Label6.Visible:=False;
Label5.Visible:=False;
Label4.Visible:=True;
Label3.Visible:=False;
end;

procedure TFormTest.Image6Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

procedure TFormTest.Image8Click(Sender: TObject);
begin
if radioButton1.Checked = true then
Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 2;
end;

procedure TFormTest.Image9Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 0;
if o1=true then Otvet:=Otvet-1;
end;

Begin
O1:=false;
O2:=false;
O3:=false;
O4:=false;
Otvet:=0;
end.
