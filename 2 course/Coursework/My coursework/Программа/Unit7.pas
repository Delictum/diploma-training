unit Unit7;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Imaging.jpeg,
  Vcl.ExtCtrls, Vcl.Imaging.pngimage;

type
  TFormHelp = class(TForm)
    ListBox1: TListBox;
    ScrollBox1: TScrollBox;
    Image1: TImage;
    Image3: TImage;
    Memo3: TMemo;
    Memo1: TMemo;
    ScrollBox2: TScrollBox;
    Label7: TLabel;
    Image6: TImage;
    Image7: TImage;
    Memo2: TMemo;
    Memo4: TMemo;
    ScrollBox3: TScrollBox;
    Label11: TLabel;
    Image9: TImage;
    Memo5: TMemo;
    Memo6: TMemo;
    Image2: TImage;
    Memo7: TMemo;
    Image4: TImage;
    ScrollBox4: TScrollBox;
    Label14: TLabel;
    Image10: TImage;
    Memo8: TMemo;
    ScrollBox5: TScrollBox;
    Label16: TLabel;
    Image11: TImage;
    Memo9: TMemo;
    Image5: TImage;
    Memo10: TMemo;
    Image8: TImage;
    Memo11: TMemo;
    ScrollBox6: TScrollBox;
    Label20: TLabel;
    Image12: TImage;
    Memo12: TMemo;
    ScrollBox7: TScrollBox;
    Label21: TLabel;
    Image13: TImage;
    Memo13: TMemo;
    Image14: TImage;
    ScrollBox8: TScrollBox;
    Label1: TLabel;
    Image15: TImage;
    Memo14: TMemo;
    ScrollBox9: TScrollBox;
    Label22: TLabel;
    Memo15: TMemo;
    ScrollBox10: TScrollBox;
    Memo16: TMemo;
    procedure ListBox1Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormHelp: TFormHelp;

implementation

{$R *.dfm}

uses Unit1;

procedure TFormHelp.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form1.Close;
end;

procedure TFormHelp.ListBox1Click(Sender: TObject);
begin
  case ListBox1.ItemIndex of
    0: begin
        formHelp.ScrollBox1.Visible := true;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    1: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := true;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    2: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := true;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    3: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := true;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
      4: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := true;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    5: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := true;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    6: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := true;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    7: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := true;
        formHelp.ScrollBox9.Visible := false;
        formHelp.ScrollBox10.Visible := false;
       end;
    8: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
        formHelp.ScrollBox7.Visible := false;
        formHelp.ScrollBox8.Visible := false;
        formHelp.ScrollBox9.Visible := true;
        formHelp.ScrollBox10.Visible := false;
       end;
  end;
end;

end.
