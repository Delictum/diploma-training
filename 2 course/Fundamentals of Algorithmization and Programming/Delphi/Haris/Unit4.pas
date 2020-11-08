unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls,
  Vcl.Imaging.GIFImg, Vcl.ExtCtrls, Vcl.Buttons, Vcl.Imaging.jpeg,
  Vcl.Imaging.pngimage;

type
  TForm4 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    BitBtn1: TBitBtn;
    Image1: TImage;
    Label1: TLabel;
    Image2: TImage;
    Image3: TImage;
    Image4: TImage;
    Image5: TImage;
    Image6: TImage;
    Image7: TImage;
    Label2: TLabel;
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
    Label7: TLabel;
    Image17: TImage;
    ComboBox1: TComboBox;
    Label8: TLabel;
    ComboBox2: TComboBox;
    ComboBox3: TComboBox;
    Image18: TImage;
    Image19: TImage;
    Image20: TImage;
    Label9: TLabel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Label10: TLabel;
    Image21: TImage;
    Image22: TImage;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    Image23: TImage;
    ListBox1: TListBox;
    Label11: TLabel;
    Image24: TImage;
    Image25: TImage;
    Image26: TImage;
    Label12: TLabel;
    Label13: TLabel;
    Edit1: TEdit;
    Image27: TImage;
    ListBox2: TListBox;
    ComboBox4: TComboBox;
    ListBox3: TListBox;
    ListBox4: TListBox;
    Label14: TLabel;
    Image28: TImage;
    Image29: TImage;
    TrackBar1: TTrackBar;
    Shape1: TShape;
    PaintBox1: TPaintBox;
    Label15: TLabel;
    Image30: TImage;
    Image31: TImage;
    Label16: TLabel;
    Image32: TImage;
    Image33: TImage;
    BitBtn2: TBitBtn;
    procedure BitBtn1Click(Sender: TObject);
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
    procedure FormCreate(Sender: TObject);

    procedure ListBox1DragDrop(Sender, Source: TObject; X, Y: Integer);
    procedure ListBox1DragOver(Sender, Source: TObject; X, Y: Integer; State: TDragState; var Accept: Boolean);
    procedure Image25Click(Sender: TObject);
    procedure Image27Click(Sender: TObject);
    procedure ComboBox4Change(Sender: TObject);
    procedure ListBox2DblClick(Sender: TObject);
    procedure ListBox4DblClick(Sender: TObject);
    procedure ListBox3DblClick(Sender: TObject);
    procedure Image29Click(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure PaintBox1Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;
  StartingPoint : TPoint;
  Otvet:integer;
  O1, O2, O3, O4, O5, O6, O7:boolean;
  Ot, list, stro3, stro4:string;

implementation

{$R *.dfm}

uses Unit2, Unit1, Unit3;

procedure TForm4.ListBox1DragDrop(Sender, Source: TObject; X, Y: Integer);
begin
  if Source=ListBox1 then ListBox1.Items.Move(ListBox1.ItemIndex,ListBox1.ItemAtPos(Point(X,Y),True));
end;

procedure TForm4.ListBox1DragOver(Sender, Source: TObject; X, Y: Integer;
  State: TDragState; var Accept: Boolean);
var xItemIndex: Integer;
begin
  xItemIndex:=ListBox1.ItemAtPos(Point(X,Y),True);
  Accept:=(Source=ListBox1) and (xItemIndex>=0) and (xItemIndex<>ListBox1.ItemIndex);
end;

procedure TForm4.ListBox2DblClick(Sender: TObject);
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

procedure TForm4.ListBox3DblClick(Sender: TObject);
Var n:integer;
begin
n:=ListBox3.ItemIndex;
if (n=-1)or(n>ListBox2.Count-1) then Exit;
ListBox2.Items.Add(ListBox3.Items.Strings[n]);
ListBox3.Items.Delete(n);
end;

procedure TForm4.ListBox4DblClick(Sender: TObject);
Var n:integer;
begin
n:=ListBox4.ItemIndex;
if (n=-1)or(n>ListBox4.Count-1) then Exit;
ListBox2.Items.Add(ListBox4.Items.Strings[n]);
ListBox4.Items.Delete(n);
end;

procedure TForm4.PaintBox1Click(Sender: TObject);
begin
with PaintBox1, canvas do
begin
    Brush.Color:=clBlack;
    Pen.Width := 10;
    moveTo(25,75);
    lineTo(50,0);
    lineTo(75,75);
    MoveTo(15,40);
    lineTo(85,60);
end;
end;

procedure TForm4.TrackBar1Change(Sender: TObject);
begin
    Shape1.Height := TrackBar1.Position;
    Shape1.Width  := TrackBar1.Position;
    Shape1.Left   := ClientWidth div 2 - Shape1.Width div 2;
    Shape1.Top    := ClientHeight div 2 + 30 - Shape1.Height div 2;
end;

procedure TForm4.BitBtn1Click(Sender: TObject);
begin
    Form1.Close;
    Form2.Close;
    Form3.Close;
    Form4.Close;
end;

procedure TForm4.BitBtn2Click(Sender: TObject);
var
  rezult : TModalResult;
begin
Otvet:=0;
rezult := MessageDlg('Are you sure you want to abort the test(the result will be reset)?',mtInformation, mbOKCancel, 0);
if rezult = mrOK then
  begin
    Form2.Show;
    Form2.PageControl1.ActivePageIndex := 0;
    FreeAndNil(form4);
Application.ProcessMessages; //����� � ��� �����, �� ����� �����
Application.CreateForm(TForm4, Form4);
    Form4.Hide;
  end;
End;

procedure TForm4.Button1Click(Sender: TObject);
begin
O5:=false;
end;

procedure TForm4.Button2Click(Sender: TObject);
begin
O5:=false;
end;

procedure TForm4.Button3Click(Sender: TObject);
begin
O5:=false;
end;

procedure TForm4.Button4Click(Sender: TObject);
begin
O5:=true;
end;

procedure TForm4.CheckBox1Click(Sender: TObject);
begin
O6:=true;
end;

procedure TForm4.CheckBox2Click(Sender: TObject);
begin
O7:=true;
end;

procedure TForm4.ComboBox1Change(Sender: TObject);
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

procedure TForm4.ComboBox2Change(Sender: TObject);
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

procedure TForm4.ComboBox3Change(Sender: TObject);
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

procedure TForm4.ComboBox4Change(Sender: TObject);
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

procedure TForm4.FormCreate(Sender: TObject);
begin
ListBox1.DragMode := dmAutomatic;
end;

procedure TForm4.Image10Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 3;
end;

procedure TForm4.Image11Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 4;
if O5=true then Otvet:=Otvet+1;
end;

procedure TForm4.Image12Click(Sender: TObject);
begin
if O6=true then Otvet:=Otvet+1;
if O7=true then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 5;
end;

procedure TForm4.Image13Click(Sender: TObject);
var it, ti:integer;
begin
for it := 1 to 7 do
with ListBox1 do
  begin
    list:=list+Items[it-1];
  end;

if List='Punk is alive, still alive punks, so Punk will never die.' then
Otvet:=Otvet+2;
PageControl1.ActivePageIndex := 6;
end;

procedure TForm4.Image14Click(Sender: TObject);
var i: integer;
begin
if edit1.Text='Grunge' then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 7;
end;

procedure TForm4.Image15Click(Sender: TObject);
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
  if ('������ � ��� ������� Sex Pistols ���� '=stro4) and ('Distemper ������ ����������� ������� Black Flag '=stro3) then Otvet:=Otvet+5;
  PageControl1.ActivePageIndex := 8;
end
else
ShowMessage('Fill out the field');
end;

procedure TForm4.Image16Click(Sender: TObject);
begin
if (trackBar1.Position>65) and (trackBar1.Position<85) then
Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 9;
Ot:=inttostr(Otvet);
Label7.Caption:=Label7.Caption+ot;
if Otvet<>1 then
label7.Caption:=Label7.Caption+' points.'
else
label7.Caption:=Label7.Caption+' point.';

if (Otvet<=12) and (Otvet>=6) then
begin
image31.Visible:=true;
label16.Caption:='Are you an anarchist.';
Form2.label5.Caption:='Hoi An Anarchist!';
end;
if Otvet>12 then
begin
image32.Visible:=true;
label16.Caption:='Are you an doll anarchy.';
Form2.label5.Caption:='Hello, doll-punk revolution!';
end;
if Otvet<6 then
begin
image33.Visible:=true;
label16.Caption:='You are an ordinary person.';
Form2.label5.Caption:='Hey Ram!';
end;
end;

procedure TForm4.Image17Click(Sender: TObject);
begin
if O2=true then Otvet:=Otvet+1;
if O3=true then Otvet:=Otvet+1;
if O4=true then Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 3;
end;

procedure TForm4.Image18Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
if O1=true then Otvet:=Otvet-1;
end;

procedure TForm4.Image19Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 2;
if O2=true then Otvet:=Otvet-1;
if O3=true then Otvet:=Otvet-1;
if O4=true then Otvet:=Otvet-1;
end;

procedure TForm4.Image21Click(Sender: TObject);
begin
if O5=true then  otvet:=Otvet-1;
PageControl1.ActivePageIndex := 3;
end;

procedure TForm4.Image23Click(Sender: TObject);
begin
if O6=true then  otvet:=Otvet-1;
if O7=true then  otvet:=Otvet-1;
PageControl1.ActivePageIndex := 4;
end;

procedure TForm4.Image25Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 5;
if List='Punk is alive, still alive punks, so Punk will never die.' then
Otvet:=Otvet-2;
end;

procedure TForm4.Image27Click(Sender: TObject);
begin
if edit1.Text='Grunge' then Otvet:=Otvet-1;
PageControl1.ActivePageIndex := 6;
end;

procedure TForm4.Image29Click(Sender: TObject);
begin
if ('������ � ��� ������� Sex Pistols ���� '=stro4) and ('Distemper ������ ����������� ������� Black Flag '=stro3)
then Otvet:=Otvet-5;
PageControl1.ActivePageIndex := 7;
end;

procedure TForm4.Image2Click(Sender: TObject);
begin
if O1=true then Otvet:=Otvet-1;
Label3.Visible:=True;
Label4.Visible:=False;
Label5.Visible:=False;
Label6.Visible:=False;
end;

procedure TForm4.Image3Click(Sender: TObject);
begin
Label4.Visible:=False;
Label3.Visible:=False;
Label5.Visible:=True;
Label6.Visible:=False;
Otvet:=Otvet+1;
O1:=true;
end;

procedure TForm4.Image4Click(Sender: TObject);
begin
Label5.Visible:=False;
Label3.Visible:=False;
Label4.Visible:=False;
Label6.Visible:=True;
end;

procedure TForm4.Image5Click(Sender: TObject);
begin
Label6.Visible:=False;
Label5.Visible:=False;
Label4.Visible:=True;
Label3.Visible:=False;
end;

procedure TForm4.Image6Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

procedure TForm4.Image8Click(Sender: TObject);
begin
if radioButton1.Checked = true then
Otvet:=Otvet+1;
PageControl1.ActivePageIndex := 2;
end;

procedure TForm4.Image9Click(Sender: TObject);
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
