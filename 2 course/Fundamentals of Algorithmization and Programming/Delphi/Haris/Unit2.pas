unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Buttons,
  Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.Mask, Vcl.Grids,
  Vcl.Samples.Calendar, Vcl.ComCtrls, Vcl.Imaging.pngimage, Vcl.MPlayer,
  Vcl.Imaging.GIFImg, Vcl.Menus, Vcl.StdActns, System.Actions, Vcl.ActnList,
  System.ImageList, Vcl.ImgList, Vcl.ToolWin, Vcl.ExtDlgs;

type
  TForm2 = class(TForm)
    BitBtn1: TBitBtn;
    Label1: TLabel;
    Label2: TLabel;
    Image1: TImage;
    Label3: TLabel;
    Label4: TLabel;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    PaintBox1: TPaintBox;
    Image2: TImage;
    Image3: TImage;
    Image4: TImage;
    Image5: TImage;
    TabSheet3: TTabSheet;
    MediaPlayer1: TMediaPlayer;
    Button1: TButton;
    OpenDialog1: TOpenDialog;
    TrackBar1: TTrackBar;
    Timer2: TTimer;
    Timer1: TTimer;
    Image6: TImage;
    Image7: TImage;
    Image8: TImage;
    Image9: TImage;
    Image10: TImage;
    Button2: TButton;
    Image11: TImage;
    Panel1: TPanel;
    Button4: TButton;
    TabSheet4: TTabSheet;
    RichEdit1: TRichEdit;
    StatusBar1: TStatusBar;
    ActionList1: TActionList;
    ImageList1: TImageList;
    FileNew: TAction;
    FileOpen: TAction;
    FileSave: TAction;
    FileSaveAs: TAction;
    EditCut1: TEditCut;
    EditCopy1: TEditCopy;
    EditPaste1: TEditPaste;
    MainMenu1: TMainMenu;
    File1: TMenuItem;
    FileNew1: TMenuItem;
    FileOpen1: TMenuItem;
    FileSave1: TMenuItem;
    FileSaveAs1: TMenuItem;
    Correction1: TMenuItem;
    EditCut11: TMenuItem;
    Copy1: TMenuItem;
    Paste1: TMenuItem;
    ToolBar1: TToolBar;
    ToolButton1: TToolButton;
    ToolButton2: TToolButton;
    ToolButton3: TToolButton;
    ToolButton4: TToolButton;
    ToolButton5: TToolButton;
    ToolButton6: TToolButton;
    ToolButton7: TToolButton;
    ToolButton8: TToolButton;
    OpenDialog2: TOpenDialog;
    SaveDialog1: TSaveDialog;
    Image13: TImage;
    ViewImage1: TMenuItem;
    Removepicture1: TMenuItem;
    RemovePicture: TAction;
    ViewImage: TAction;
    OpenPictureDialog1: TOpenPictureDialog;
    StretchText: TAction;
    StretchText1: TMenuItem;
    Transcription: TAction;
    ranscription1: TMenuItem;
    TabSheet5: TTabSheet;
    PaintBox2: TPaintBox;
    Image14: TImage;
    Image15: TImage;
    Image16: TImage;
    Image17: TImage;
    Image12: TImage;
    Image18: TImage;
    Image22: TImage;
    Label5: TLabel;
    Font1: TMenuItem;
    procedure BitBtn1Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Calendar1Change(Sender: TObject);
    procedure PaintBox1Click(Sender: TObject);
    procedure Image4Click(Sender: TObject);
    procedure Image5Click(Sender: TObject);
    procedure Image2Click(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure Image6Click(Sender: TObject);
    procedure Image7Click(Sender: TObject);
    procedure Image8Click(Sender: TObject);
    procedure Image9Click(Sender: TObject);
    procedure Image10Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Image11Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure FileNewExecute(Sender: TObject);
    procedure FileOpenExecute(Sender: TObject);
    procedure Image12Click(Sender: TObject);
    procedure FileSaveExecute(Sender: TObject);
    procedure FileSaveAsExecute(Sender: TObject);
    procedure FileNew1Click(Sender: TObject);
    procedure FileOpen1Click(Sender: TObject);
    procedure FileSave1Click(Sender: TObject);
    procedure FileSaveAs1Click(Sender: TObject);
    procedure ViewImageExecute(Sender: TObject);
    procedure RemovePictureExecute(Sender: TObject);
    procedure StretchTextExecute(Sender: TObject);
    procedure TranscriptionExecute(Sender: TObject);
    procedure PaintBox2Click(Sender: TObject);
    procedure Image15Click(Sender: TObject);
    procedure Image16Click(Sender: TObject);
    procedure Image17Click(Sender: TObject);
    procedure Image18Click(Sender: TObject);
    procedure Image22Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Font1Click(Sender: TObject);

      var
  private
    { Private declarations }
  public
    { Public declarations }
  FileName: string;
  end;

var
  Form2: TForm2;
  play, VA:boolean;
  k, i:integer;
  mas:array[1..17] of string;

implementation

{$R *.dfm}

uses Unit1, Unit3, Unit4, Unit5;

procedure TForm2.StretchTextExecute(Sender: TObject);
begin
RichEdit1.Align:=alClient;
end;

procedure TForm2.BitBtn1Click(Sender: TObject);
  begin
    Form1.Close;
    Form2.Close;
    Form3.Close;
    Form4.Close;
    Form5.Close;
  end;

procedure TForm2.Button1Click(Sender: TObject);
begin
k:=1;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\���� - ���� ������� �� �����.mp3';
        mas[1]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\������ ����  - �� - ������!.mp3';
        mas[2]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\������ ���� - ���������� ���.mp3';
        mas[3]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\Bog[]morok - ������������ (New_Single_2012).mp3';
        mas[4]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\Distemper - �� ��� ������.mp3';
        mas[5]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\PunKrot - ���-�-�������� (2014).mp3';
        mas[6]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\Sex Pistols - Holidays In the Sun.mp3';
        mas[7]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\Sex Pistols - No Feelings.mp3';
        mas[8]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\������ ��� � ��. ���� - ���� �������.mp3';
        mas[9]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\��� ������ - �� ������.mp3';
        mas[10]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\���� - ������ ����.mp3';
        mas[11]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\��������.mp3';
        mas[12]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\��������� �����_ ��� ����� �������! - YouTube [720p] (2).wmv';
        mas[13]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\��������� �����_ ��� ����� �������! - YouTube [720p].wmv';
        mas[14]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\������� ������� ������ � ���.wmv';
        mas[15]:=MediaPlayer1.FileName;
        MediaPlayer1.FileName := 'C:\25 ����\����\Delphi\Haris\Win32\Debug\Audio\��������� �����_ ��� ����� �������! - YouTube [720p] (2).wmv';
        mas[16]:=MediaPlayer1.FileName;

     MediaPlayer1.FileName:=mas[k];
     MediaPlayer1.Open;
     TrackBar1.Max:=MediaPlayer1.Length;
     inc(k);
     timer2.Enabled:=true;
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
if OpenDialog1.Execute then
begin
MediaPlayer1.FileName:=OpenDialog1.FileName;
mediaplayer1.Display:=panel1;
MediaPlayer1.Open;
TrackBar1.Max:=MediaPlayer1.Length;
timer2.Enabled:=true;
end;
VA:=false;
end;

procedure TForm2.Button4Click(Sender: TObject);
begin
Form1.Timer1.Enabled:=false;
Form1.ProgressBar1.Position:=0;
Form1.Show;
MediaPlayer1.Stop;
MediaPlayer1.Position:=0;
Form2.Close;
end;

procedure TForm2.Calendar1Change(Sender: TObject);
begin
Label3.Caption:=DateToStr(Now);
end;


procedure TForm2.FileNew1Click(Sender: TObject);
begin
 RichEdit1.Clear;
  FileName:= 'Untitled.txt';
  StatusBar1.Panels[0].Text:= FileName;
end;

procedure TForm2.FileNewExecute(Sender: TObject);
begin
RichEdit1.Clear;
  FileName:= 'Untitled.txt';
  StatusBar1.Panels[0].Text:= FileName;
end;

procedure TForm2.FileOpen1Click(Sender: TObject);
begin
  if OpenDialog2.Execute then
  begin
    RichEdit1.Lines.LoadFromFile(OpenDialog2.FileName);
    FileName:= OpenDialog1.FileName;
    StatusBar1.Panels[0].Text:= FileName;
  end;
end;

procedure TForm2.FileOpenExecute(Sender: TObject);
begin
  if OpenDialog2.Execute then
  begin
    RichEdit1.Lines.LoadFromFile(OpenDialog2.FileName);
    FileName:= OpenDialog1.FileName;
    StatusBar1.Panels[0].Text:= FileName;
  end;
end;

procedure TForm2.FileSave1Click(Sender: TObject);
begin
  if FileName = 'Untitled.txt' then
    FileSaveAsExecute(nil)
  else
    RichEdit1.Lines.SaveToFile(FileName);
end;

procedure TForm2.FileSaveAs1Click(Sender: TObject);
begin
  SaveDialog1.FileName:= FileName;
  SaveDialog1.InitialDir:= ExtractFilePath(FileName);
  if SaveDialog1.Execute then
  begin
    RichEdit1.Lines.SaveToFile(SaveDialog1.FileName);
    FileName:= SaveDialog1.FileName;
    StatusBar1.Panels[0].Text:= FileName;
  end;
end;

procedure TForm2.FileSaveAsExecute(Sender: TObject);
begin
  SaveDialog1.FileName:= FileName;
  SaveDialog1.InitialDir:= ExtractFilePath(FileName);
  if SaveDialog1.Execute then
  begin
    RichEdit1.Lines.SaveToFile(SaveDialog1.FileName);
    FileName:= SaveDialog1.FileName;
    StatusBar1.Panels[0].Text:= FileName;
  end;
end;

procedure TForm2.FileSaveExecute(Sender: TObject);
begin
  if FileName = 'Untitled.txt' then
    FileSaveAsExecute(nil)
  else
    RichEdit1.Lines.SaveToFile(FileName);
end;

procedure TForm2.Font1Click(Sender: TObject);
begin
Form2.Hide;
Form5.Show;
end;

procedure TForm2.FormCreate(Sender: TObject);
begin
Application.Title:= 'Oblivion';
end;

procedure TForm2.Image10Click(Sender: TObject);
begin
if VA=True then 
begin
     k:=k-1;
     if k=0 then k:=16;
     MediaPlayer1.FileName:=mas[k];
     mediaplayer1.Display:=panel1;
     MediaPlayer1.Open;
     TrackBar1.Max:=MediaPlayer1.Length;
     MediaPlayer1.Play;
end;
end;

procedure TForm2.Image11Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

procedure TForm2.Image17Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 3;
end;

procedure TForm2.Image18Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 0;
end;

procedure TForm2.Image15Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 2;
end;

procedure TForm2.Image12Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 3;
end;

procedure TForm2.Image16Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 4;
end;

procedure TForm2.Image22Click(Sender: TObject);
var
  rezult : TModalResult;
begin
rezult := MessageDlg('Find yourself a rebellious side. Somewhere will be correct one answer, but somewhere a few. God be with you punk rock (this is not a joke).',mtInformation, mbOKCancel, 0);
  if rezult = mrOK then
  begin
    form1.Timer1.Enabled:=false;
    if TrackBar1.Position=0 then
    begin
    button1.Click;
    VA:=true;
    MediaPlayer1.Play;
    end;
    Form2.Hide;
    Form4.PageControl1.ActivePageIndex := 0;
    Form4.Refresh;
    Form4.Show;
  end;
end;

procedure TForm2.Image2Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 2;
end;

procedure TForm2.Image4Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

procedure TForm2.Image5Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 0;
end;

procedure TForm2.Image6Click(Sender: TObject);
begin
VA:=true;
MediaPlayer1.Play;
end;

procedure TForm2.Image7Click(Sender: TObject);
begin
  MediaPlayer1.Stop;
  MediaPlayer1.Position:=0;
end;

procedure TForm2.Image8Click(Sender: TObject);
begin
MediaPlayer1.Pause;
end;

procedure TForm2.Image9Click(Sender: TObject);
begin
if VA=True then
begin
     inc(k);
     if k=17 then k:=1;
     mediaplayer1.Display:=panel1;     
     MediaPlayer1.FileName:=mas[k];
     MediaPlayer1.Open;
     TrackBar1.Max:=MediaPlayer1.Length;
     MediaPlayer1.Play;
end;
end;

procedure TForm2.PaintBox1Click(Sender: TObject);
begin
with PaintBox1, canvas do
    begin
    PaintBox1.Canvas.Pen.Color:=clBlack;
    Canvas.Brush.Color:=clBlack;
    PaintBox1.Canvas.Ellipse (160,170,PaintBox1.Width-260,PaintBox1.Height-260);
    Brush.Color := clBlack;
    Pen.Width := 4;
    Pen.Color := clWhite;
    Pen.Style := psDash;
    Pen.Width := 1;
    Pen.Color := clBlack;
    Polyline([Point(40, 10), Point(20, 60), Point(70, 30),
    Point(10, 30), Point(60, 60), Point(40, 10)]);
    Pen.Color := clWhite;
    Polyline([Point(90, 190), Point(120, 75), Point(150, 170)]);
    Polyline([Point(80, 120), Point(160, 120)]);
    Brush.Color := clWhite;
    TextOut(75,20,'Taste the horror of the abyss...');
    end;
end;

procedure TForm2.PaintBox2Click(Sender: TObject);
begin
with PaintBox2, canvas do
begin
    Brush.Color:=clLime;
    FloodFill(3,3,clBlack, fsBorder);

    Pen.Width := 1;
    Pen.Style := psDash;
    Brush.Color := clBlue;
    rectangle(0,0,877,90);

    Pen.Width := 16;
    Pen.Color := clGreen;
    Polygon([Point(550,110), Point(590,110), Point(570,090), Point(550,110)]);
    Polygon([Point(550,090), Point(590,090), Point(570,070), Point(550,090)]);
    Polygon([Point(550,070), Point(590,070), Point(570,050), Point(550,070)]);
    Pen.Color := clOlive;
    Brush.Color := clOlive;
    rectangle(565,115,575,130);

    Pen.Color := clGreen;
    Polygon([Point(350,110), Point(390,110), Point(370,090), Point(350,110)]);
    Polygon([Point(350,090), Point(390,090), Point(370,070), Point(350,090)]);
    Polygon([Point(350,070), Point(390,070), Point(370,050), Point(350,070)]);
    Pen.Color := clOlive;
    Brush.Color := clOlive;
    rectangle(365,115,375,130);

    Pen.Color := clGreen;
    Polygon([Point(450,110), Point(490,110), Point(470,090), Point(450,110)]);
    Polygon([Point(450,090), Point(490,090), Point(470,070), Point(450,090)]);
    Polygon([Point(450,070), Point(490,070), Point(470,050), Point(450,070)]);
    Pen.Color := clOlive;
    Brush.Color := clOlive;
    rectangle(465,115,475,130);

    Pen.Width := 1;
    Pen.Color :=clYellow;
    Brush.Color := clYellow;
    Canvas.Chord(0,50, 200,420, 200,0, 0,0);

    Pen.Color :=clSilver;
    Brush.Color := clSilver;
    Polygon([Point(90,90),Point(525,570),Point(877,570),Point(145,90)]);

     Pen.Style := psSolid;
     Pen.Color :=clBlack;
     Brush.Color := clGray;
     Ellipse(555,460,535,440);
     Ellipse(450,370,470,390);
     Brush.Color := clMaroon;
     Polygon([Point(460,370),Point(540,440),Point(420,340),Point(445,360),
     Point(420,340),Point(465,330),Point(540,340),Point(465,330),
     Point(540,340),Point(620,395),Point(630,450),Point(620,395),
     Point(630,450),Point(610,475),Point(555,450),Point(610,475),
     Point(460,370),Point(535,340)]);
     moveTo(550,440);
     lineTo(620,400);
end;
end;

procedure TForm2.RemovePictureExecute(Sender: TObject);
begin
Image13.Picture:=nil;
end;

procedure TForm2.Timer1Timer(Sender: TObject);
begin
Label4.Caption:=TimeToStr(Now);
if PageControl1.ActivePageIndex <> 3 then
begin
 Form2.MainMenu1.AutoMerge:=True;
 SetMenu(Handle,0);
end
 else
 SetMenu(Handle,MainMenu1.Handle);
end;

procedure TForm2.Timer2Timer(Sender: TObject);
begin
  TrackBar1.Position:=MediaPlayer1.Position;
end;

procedure TForm2.TrackBar1Change(Sender: TObject);
begin
if ABS(mediaplayer1.Position - TrackBar1.Position) > 1000 then
begin
If TrackBar1.Position<>mediaplayer1.Position then mediaplayer1.Position:=TrackBar1.Position;
mediaplayer1.Play;
end;
if va = True then
if TrackBar1.Max=MediaPlayer1.Position then  Image9Click(Sender);
end;

procedure TForm2.TranscriptionExecute(Sender: TObject);
begin
RichEdit1.Align:=alNone;
end;

procedure TForm2.ViewImageExecute(Sender: TObject);
begin
if OpenPictureDialog1.Execute then
Image13.Picture.LoadFromFile(OpenPictureDialog1.FileName);
end;

Begin
VA:=true;
end.
