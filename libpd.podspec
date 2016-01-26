Pod::Spec.new do |s|
  s.name = "libpd"
  s.version = "0.8.2"

  s.license = { :type => 'Standard Improved BSD License', :file => 'License.txt' }

  s.summary = "Pure Data embeddable audio synthesis library, useful as a sound engine in mobile phone apps, games, web pages, and art projects"
  s.homepage = "https://github.com/amethystdeceiver/libpd"
  s.authors = "Peter Brinkmann", "Dan Wilcox", "Rich Eakin", "Miller Puckette (Pure Data)"

  s.source = { :git => "https://github.com/amethystdeceiver/libpd.git", :commit => "HEAD" }
  s.source_files = 'cpp/**/*.{hpp,cpp}', 'libpd_wrapper/**/*.{h,c}', 'objc/**/*.{h,m}', 'pure-data/src/**/*.{h,c}', 'pure-data/extra/**/*.{h,c}'
  s.exclude_files = '**/d_fft_fftw.c', '**/s_audio_alsa.c', '**/s_audio_alsamm.c', '**/s_audio_mmio.c', '**/s_audio_oss.c', '**/s_audio_pa.c', '**/s_midi_alsa.c', '**/s_midi_mmio.c', '**/s_midi_oss.c', '**/s_midi_pm.c'

  s.ios.deployment_target = '6.0'

  s.frameworks = 'Foundation', 'AudioToolbox', 'AVFoundation', 'Accelerate'
  s.compiler_flags = '-DPD', '-DUSEAPI_DUMMY', '-DHAVE_UNISTD_H', '-DHAVE_ALLOCA_H'#, '-DLIBPD_EXTRA'
  s.requires_arc = false
end
