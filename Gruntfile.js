module.exports = function (grunt) {

    var path = require('path');

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Load information about the assembly
	var assembly = grunt.file.readJSON('src/' + pkg.name + '/Properties/AssemblyInfo.json');

	// Get the version of the package
    var version = assembly.informationalVersion ? assembly.informationalVersion : assembly.version;

	grunt.initConfig({
	    pkg: pkg,
	    nugetpack: {
	        release: {
	            src: 'src/' + pkg.name + '/' + pkg.name + '.csproj',
	            dest: 'releases/nuget/'
	        }
	    },
		zip: {
		    release: {
		        router: function (filepath) {
		            return path.basename(filepath);
		        },
		        src: [
					'src/' + pkg.name + '/bin/Release/Skybrud.Social.Core.dll',
					'src/' + pkg.name + '/bin/Release/Skybrud.Social.Core.xml',
					'src/' + pkg.name + '/bin/Release/' + pkg.name + '.dll',
					'src/' + pkg.name + '/bin/Release/' + pkg.name + '.xml',
					'src/' + pkg.name + '/LICENSE.txt'
				],
		        dest: 'releases/github/' + pkg.name + '.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-nuget');
	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('release', ['nugetpack', 'zip']);

	grunt.registerTask('default', ['release']);

};