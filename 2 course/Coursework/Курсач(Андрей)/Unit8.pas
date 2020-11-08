unit Unit8;

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
    ScrollBox2: TScrollBox;
    Label7: TLabel;
    Image6: TImage;
    Memo2: TMemo;
    ScrollBox3: TScrollBox;
    Label11: TLabel;
    Image2: TImage;
    Image4: TImage;
    Memo7: TMemo;
    ScrollBox4: TScrollBox;
    Label14: TLabel;
    Image10: TImage;
    Memo8: TMemo;
    Image5: TImage;
    ScrollBox5: TScrollBox;
    Label16: TLabel;
    Image7: TImage;
    Image8: TImage;
    Memo9: TMemo;
    ScrollBox6: TScrollBox;
    Label22: TLabel;
    Memo15: TMemo;
    procedure ListBox1Click(Sender: TObject);
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
       end;
    1: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := true;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
       end;
    2: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := true;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
       end;
    3: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := true;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := false;
       end;
      4: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := true;
        formHelp.ScrollBox6.Visible := false;
       end;
    5: begin
        formHelp.ScrollBox1.Visible := false;
        formHelp.ScrollBox2.Visible := false;
        formHelp.ScrollBox3.Visible := false;
        formHelp.ScrollBox4.Visible := false;
        formHelp.ScrollBox5.Visible := false;
        formHelp.ScrollBox6.Visible := true;
       end;
  end;
end;

end.
