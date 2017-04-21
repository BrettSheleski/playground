/// <reference path="createjs-2015.11.26.min.js" />
/// <reference path="complex.js" />

Mandelbrot = (function (createjs) {

    function Mandelbrot(canvas, options) {
        var self = this;

        self.stage = new createjs.Stage(canvas);

        self.scale = Math.min( 3 / canvas.width, 2 / canvas.height);
        self.origin = {
            x : 2 * canvas.width / 3,
            y : canvas.height / 2
        };

        self.container = new createjs.Container();

        var p = null;

        self.container.on("mousedown", function(evt){
            p = {x : evt.stageX, y : evt.stageY};
        })

        self.container.on("pressmove", function(evt){
         
            self.container.x += (evt.stageX - p.x) / self.container.scaleX;
            self.container.y += (evt.stageY - p.y) / self.container.scaleY;

            self.stage.update();

            p = {x : evt.stageX, y : evt.stageY};
        });

        self.container.on("dblclick", function(evt){

            self.container.regX = evt.stageX / self.container.scaleX;
            self.container.regY = evt.stageY / self.container.scaleY;

            self.container.scaleX *= 1.1;
            self.container.scaleY *= 1.1;

            self.stage.update();
        })

        self.stage.addChild(self.container);
        
    }

    var p = Mandelbrot.prototype;

    function getDivergance(z, c, stepsLeft){

        //var newC = 

    }

    p.draw = function(){

        var center = {x : this.stage.canvas.width / 2, y : this.stage.canvas.height / 2};

        var z, re, im;

        for(var i = 0 ; i < this.stage.canvas.width; ++i){
            for(var j = 0; j < this.stage.canvas.height; ++j){

                    z = new Complex({
                        re: (i - this.origin.x) *this.scale,
                         im: (j - this.origin.y) * this.scale
                    });
            }
        }


        alert("X: " + center.x + " Y : " + center.y);

    }

    return Mandelbrot;
})(createjs)