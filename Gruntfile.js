module.exports = function(grunt) {
  grunt.initConfig({
    clean: ["wwwroot/lib/*"],
    
    copy: {
    //   bootstrap: {
    //     expand: true,
    //     cwd: 'node_modules/bootstrap/dist/',
    //     src: ['**'],
    //     dest: 'wwwroot/lib/bootstrap/'
    //   },
      bootstrap_icons: {
        expand: true,
        cwd: 'node_modules/bootstrap-icons/font/',
        src: ['**'],
        dest: 'wwwroot/lib/bootstrap-icons/font/'
      },
    //   jquery: {
    //     expand: true,
    //     cwd: 'node_modules/jquery/dist/',
    //     src: ['jquery*.js'],
    //     dest: 'wwwroot/lib/jquery/'
    //   }
    }
  });

  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-copy');
  
  grunt.registerTask("default", ["clean", "copy"]);
};